﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using EventsLibrary;
using Productivity.Analysis;

namespace Productivity
{
    public partial class ProductivityBar : UserControl
    {
        private IList<TimelineSegment> segments;
        private int lastToolTipPixel = -1;

        public ProductivityBar()
        {
            InitializeComponent();
            this.StartTime = DateTime.Today.ToUniversalTime();
            this.TimeSpan = TimeSpan.FromDays(1);
        }

        public IList<TimelineSegment> Segments
        {
            get
            {
                return this.segments;
            }

            set
            {
                if (value == null)
                {
                    this.segments = null;
                }
                else
                {
                    var list = value.ToList();
                    list.Sort((a, b) => a.StartTime.CompareTo(b.StartTime));
                    this.segments = list.AsReadOnly();
                }

                this.lastToolTipPixel = -1;
                this.Invalidate();
            }
        }

        public DateTime StartTime { get; set; }

        public TimeSpan TimeSpan { get; set; }

        protected override void OnResize(EventArgs e)
        {
            this.lastToolTipPixel = -1;
            this.Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            g.SmoothingMode = SmoothingMode.HighSpeed;

            var background = new HatchBrush(HatchStyle.LargeCheckerBoard, Color.White, Color.Silver);
            g.FillRectangle(background, this.ClientRectangle);

            if (this.segments != null)
            {
                var left = e.ClipRectangle.Left;
                var right = e.ClipRectangle.Right;
                var top = e.ClipRectangle.Top;
                var bottom = e.ClipRectangle.Bottom;

                var totalMs = this.TimeSpan.TotalMilliseconds;
                var keyTime = this.StartTime;
                var endTime = keyTime;
                var startTime = endTime;

                for (int x = left; x <= right; x++)
                {
                    startTime = endTime;
                    endTime = GetPixelTime(x + 1);
                    var currentSegments = FindSegments(startTime, endTime);
                    if (currentSegments.Count > 0)
                    {
                        var barMs = (endTime - startTime).TotalMilliseconds;
                        var unkonwnMs = barMs;
                        var productiveMs = 0.0;
                        var unproductiveMs = 0.0;

                        foreach (var segment in currentSegments)
                        {
                            if (segment.Productivity.HasValue)
                            {
                                var clampedStart = segment.StartTime.Clamp(startTime, endTime);
                                var clampedEnd = segment.EndTime.Clamp(startTime, endTime);

                                var segmentMs = (clampedEnd - clampedStart).TotalMilliseconds;
                                var productivePortion = segmentMs * (segment.Productivity.Value / 100.0);
                                var unproductivePortion = segmentMs - productivePortion;

                                productiveMs += productivePortion;
                                unproductiveMs += unproductivePortion;
                                unkonwnMs -= segmentMs;
                            }
                        }

                        if (barMs != unkonwnMs)
                        {
                            // Re-calculate the bar's time to compensate for rounding error.
                            barMs = unkonwnMs + productiveMs + unproductiveMs;
                            var unknown = unkonwnMs / barMs;

                            // Base the colors on only the portion of time that is productive or unproductive.
                            barMs = productiveMs + unproductiveMs;
                            var productive = productiveMs / barMs;

                            var pen = new Pen(GetColorForProductivity(unknown, productive));
                            g.DrawLine(pen, x, top, x, bottom);
                        }
                    }
                }
            }

            g.DrawRectangle(Pens.Black, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }

        private Color GetColorForProductivity(double unknown, double productive)
        {
            var a = (int)(256 * (1.0 - unknown)).Clamp(0, 255);
            var r = (int)(512 - 512 * productive).Clamp(0, 255);
            var g = (int)(512 * productive).Clamp(0, 255);
            var b = 0;

            return Color.FromArgb(a, r, g, b);
        }

        private List<TimelineSegment> FindSegments(DateTime startTime, DateTime endTime)
        {
            return this.segments.Where(s => s.StartTime <= endTime && s.EndTime >= startTime).ToList();
        }

        private DateTime GetPixelTime(int x)
        {
            return this.StartTime.AddMilliseconds(this.TimeSpan.TotalMilliseconds * ((double)x / this.Width));
        }

        private void ProductivityBar_MouseMove(object sender, MouseEventArgs e)
        {
            var x = e.X;
            if (this.lastToolTipPixel != x)
            {
                var startTime = GetPixelTime(x);
                var endTime = GetPixelTime(x + 1);

                var segments = FindSegments(startTime, endTime);

                this.segmentsToolTip.SetToolTip(this, string.Join("\n", segments.Select(s => s.ToString())));
                this.lastToolTipPixel = x;
            }
        }
    }
}
