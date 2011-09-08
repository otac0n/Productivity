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
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Rule> Rules
        {
            get
            {
                if ((_Rules == null))
                {
                    _Rules = base.CreateObjectSet<Rule>("Rules");
                }
                return _Rules;
            }
        }
        private ObjectSet<Rule> _Rules;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Events EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToEvents(Event @event)
        {
            base.AddObject("Events", @event);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Rules EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToRules(Rule rule)
        {
            base.AddObject("Rules", rule);
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
        /// <param name="startTime">Initial value of the StartTime property.</param>
        /// <param name="endTime">Initial value of the EndTime property.</param>
        /// <param name="duration">Initial value of the Duration property.</param>
        /// <param name="type">Initial value of the Type property.</param>
        /// <param name="data">Initial value of the Data property.</param>
        public static Event CreateEvent(global::System.Guid eventId, global::System.DateTime startTime, global::System.DateTime endTime, global::System.String duration, global::System.String type, global::System.String data)
        {
            Event @event = new Event();
            @event.EventId = eventId;
            @event.StartTime = startTime;
            @event.EndTime = endTime;
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
        public global::System.DateTime StartTime
        {
            get
            {
                return _StartTime;
            }
            set
            {
                OnStartTimeChanging(value);
                ReportPropertyChanging("StartTime");
                _StartTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("StartTime");
                OnStartTimeChanged();
            }
        }
        private global::System.DateTime _StartTime;
        partial void OnStartTimeChanging(global::System.DateTime value);
        partial void OnStartTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime EndTime
        {
            get
            {
                return _EndTime;
            }
            set
            {
                OnEndTimeChanging(value);
                ReportPropertyChanging("EndTime");
                _EndTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("EndTime");
                OnEndTimeChanged();
            }
        }
        private global::System.DateTime _EndTime;
        partial void OnEndTimeChanging(global::System.DateTime value);
        partial void OnEndTimeChanged();
    
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
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Productivity.Models", Name="Rule")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Rule : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Rule object.
        /// </summary>
        /// <param name="ruleId">Initial value of the RuleId property.</param>
        /// <param name="order">Initial value of the Order property.</param>
        /// <param name="expression">Initial value of the Expression property.</param>
        /// <param name="description">Initial value of the Description property.</param>
        public static Rule CreateRule(global::System.Guid ruleId, global::System.Int32 order, global::System.String expression, global::System.String description)
        {
            Rule rule = new Rule();
            rule.RuleId = ruleId;
            rule.Order = order;
            rule.Expression = expression;
            rule.Description = description;
            return rule;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid RuleId
        {
            get
            {
                return _RuleId;
            }
            set
            {
                if (_RuleId != value)
                {
                    OnRuleIdChanging(value);
                    ReportPropertyChanging("RuleId");
                    _RuleId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("RuleId");
                    OnRuleIdChanged();
                }
            }
        }
        private global::System.Guid _RuleId;
        partial void OnRuleIdChanging(global::System.Guid value);
        partial void OnRuleIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Order
        {
            get
            {
                return _Order;
            }
            set
            {
                OnOrderChanging(value);
                ReportPropertyChanging("Order");
                _Order = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Order");
                OnOrderChanged();
            }
        }
        private global::System.Int32 _Order;
        partial void OnOrderChanging(global::System.Int32 value);
        partial void OnOrderChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Expression
        {
            get
            {
                return _Expression;
            }
            set
            {
                OnExpressionChanging(value);
                ReportPropertyChanging("Expression");
                _Expression = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Expression");
                OnExpressionChanged();
            }
        }
        private global::System.String _Expression;
        partial void OnExpressionChanging(global::System.String value);
        partial void OnExpressionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Productivity
        {
            get
            {
                return _Productivity;
            }
            set
            {
                OnProductivityChanging(value);
                ReportPropertyChanging("Productivity");
                _Productivity = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Productivity");
                OnProductivityChanged();
            }
        }
        private Nullable<global::System.Int32> _Productivity;
        partial void OnProductivityChanging(Nullable<global::System.Int32> value);
        partial void OnProductivityChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();

        #endregion
    
    }

    #endregion
    
}
