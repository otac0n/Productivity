using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Productivity.Analysis;
using System.Drawing.Drawing2D;

namespace Productivity
{
    public partial class ProductivityBar : UserControl
    {
        private IList<TimelineSegment> segments;

        public ProductivityBar()
        {
            InitializeComponent();
            this.StartTime = new DateTimeOffset(DateTime.Today.ToUniversalTime(), TimeSpan.FromHours(0));
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
                    this.segments = value.ToList().AsReadOnly();
                }

                this.Invalidate();
            }
        }

        public DateTimeOffset StartTime { get; set; }

        public TimeSpan TimeSpan { get; set; }

        protected override void OnResize(EventArgs e)
        {
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

                var pen = new Pen(Color.FromArgb(255, 255, 0, 0));

                var totalMs = this.TimeSpan.TotalMilliseconds;
                var keyTime = this.StartTime.ToUniversalTime().DateTime;
                var endTime = keyTime;
                var startTime = endTime;

                for (int x = left; x <= right; x++)
                {
                    startTime = endTime;
                    endTime = keyTime.AddMilliseconds(totalMs * ((double)x / this.Width));
                    if (this.segments.Any(s => s.StartTime <= endTime && s.EndTime >= startTime))
                    {
                        g.DrawLine(pen, x, top, x, bottom);
                    }
                }
            }

            g.DrawRectangle(Pens.Black, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }
    }
}
