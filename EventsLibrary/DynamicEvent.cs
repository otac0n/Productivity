using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Web.Script.Serialization;

namespace EventsLibrary
{
    public class DynamicEvent
    {
        private readonly DateTime startTime;
        private readonly DateTime endTime;
        private readonly dynamic data;
        private readonly string type;

        public DynamicEvent(DateTime startTime, DateTime endTime, string data, string type)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.type = type;

            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
            this.data = serializer.Deserialize(data, typeof(object));
        }

        public DateTime StartTime
        {
            get
            {
                return this.startTime;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return this.endTime;
            }
        }

        public dynamic Data
        {
            get
            {
                return this.data;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
        }

        private sealed class DynamicJsonConverter : JavaScriptConverter
        {
            public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
            {
                if (dictionary == null)
                    throw new ArgumentNullException("dictionary");

                return type == typeof(object) ? new DynamicJsonObject(dictionary) : null;
            }

            public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override IEnumerable<Type> SupportedTypes
            {
                get { return new ReadOnlyCollection<Type>(new List<Type>(new[] { typeof(object) })); }
            }

            private sealed class DynamicJsonObject : DynamicObject
            {
                private readonly IDictionary<string, object> storage;

                public DynamicJsonObject(IDictionary<string, object> data)
                {
                    if (data == null)
                    {
                        throw new ArgumentNullException("data");
                    }

                    this.storage = data;
                }

                public override bool TryGetMember(GetMemberBinder binder, out object result)
                {
                    if (!this.storage.TryGetValue(binder.Name, out result))
                    {
                        result = null;
                        return true;
                    }

                    var dictionary = result as IDictionary<string, object>;
                    if (dictionary != null)
                    {
                        result = new DynamicJsonObject(dictionary);
                        return true;
                    }

                    var arrayList = result as ArrayList;
                    if (arrayList != null && arrayList.Count > 0)
                    {
                        if (arrayList[0] is IDictionary<string, object>)
                            result = new List<object>(arrayList.Cast<IDictionary<string, object>>().Select(x => new DynamicJsonObject(x)));
                        else
                            result = new List<object>(arrayList.Cast<object>());
                    }

                    return true;
                }

                public override IEnumerable<string> GetDynamicMemberNames()
                {
                    return this.storage.Keys;
                }
            }
        }
    }
}
