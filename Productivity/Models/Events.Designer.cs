﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace Productivity.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class EventsConnection : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new EventsConnection object using the connection string found in the 'EventsConnection' section of the application configuration file.
        /// </summary>
        public EventsConnection() : base("name=EventsConnection", "EventsConnection")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new EventsConnection object.
        /// </summary>
        public EventsConnection(string connectionString) : base(connectionString, "EventsConnection")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new EventsConnection object.
        /// </summary>
        public EventsConnection(EntityConnection connection) : base(connection, "EventsConnection")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Event> Events
        {
            get
            {
                if ((_Events == null))
                {
                    _Events = base.CreateObjectSet<Event>("Events");
                }
                return _Events;
            }
        }
        private ObjectSet<Event> _Events;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Events EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToEvents(Event @event)
        {
            base.AddObject("Events", @event);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Productivity.Models", Name="Event")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Event : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Event object.
        /// </summary>
        /// <param name="eventId">Initial value of the EventId property.</param>
        /// <param name="time">Initial value of the Time property.</param>
        /// <param name="duration">Initial value of the Duration property.</param>
        /// <param name="type">Initial value of the Type property.</param>
        /// <param name="data">Initial value of the Data property.</param>
        public static Event CreateEvent(global::System.Guid eventId, global::System.DateTime time, global::System.String duration, global::System.String type, global::System.String data)
        {
            Event @event = new Event();
            @event.EventId = eventId;
            @event.Time = time;
            @event.Duration = duration;
            @event.Type = type;
            @event.Data = data;
            return @event;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid EventId
        {
            get
            {
                return _EventId;
            }
            set
            {
                if (_EventId != value)
                {
                    OnEventIdChanging(value);
                    ReportPropertyChanging("EventId");
                    _EventId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("EventId");
                    OnEventIdChanged();
                }
            }
        }
        private global::System.Guid _EventId;
        partial void OnEventIdChanging(global::System.Guid value);
        partial void OnEventIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Time
        {
            get
            {
                return _Time;
            }
            set
            {
                OnTimeChanging(value);
                ReportPropertyChanging("Time");
                _Time = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Time");
                OnTimeChanged();
            }
        }
        private global::System.DateTime _Time;
        partial void OnTimeChanging(global::System.DateTime value);
        partial void OnTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Duration
        {
            get
            {
                return _Duration;
            }
            set
            {
                OnDurationChanging(value);
                ReportPropertyChanging("Duration");
                _Duration = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Duration");
                OnDurationChanged();
            }
        }
        private global::System.String _Duration;
        partial void OnDurationChanging(global::System.String value);
        partial void OnDurationChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Type
        {
            get
            {
                return _Type;
            }
            set
            {
                OnTypeChanging(value);
                ReportPropertyChanging("Type");
                _Type = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Type");
                OnTypeChanged();
            }
        }
        private global::System.String _Type;
        partial void OnTypeChanging(global::System.String value);
        partial void OnTypeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Data
        {
            get
            {
                return _Data;
            }
            set
            {
                OnDataChanging(value);
                ReportPropertyChanging("Data");
                _Data = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Data");
                OnDataChanged();
            }
        }
        private global::System.String _Data;
        partial void OnDataChanging(global::System.String value);
        partial void OnDataChanged();

        #endregion
    
    }

    #endregion
    
}
