namespace EventsLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.Serialization.Json;
    using System.Threading;
    using System.Runtime.Serialization;
    using System.IO;

    public static class DataSerializer
    {
        private static readonly ReaderWriterLockSlim serializersLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        private static Dictionary<Type, XmlObjectSerializer> serializersCache = new Dictionary<Type, XmlObjectSerializer>();

        public static string Serialize<T>(T data)
        {
            if (data == null)
            {
                return null;
            }

            var serializer = GetSerializer(typeof(T));

            lock (serializer)
            {
                using (var memoryStream = new MemoryStream())
                {
                    serializer.WriteObject(memoryStream, data);
                    return Encoding.UTF8.GetString(memoryStream.GetBuffer());
                }
            }
        }

        private static XmlObjectSerializer GetSerializer(Type type)
        {
            XmlObjectSerializer serializer;

            serializersLock.EnterReadLock();
            try
            {
                if (serializersCache.TryGetValue(type, out serializer))
                {
                    return serializer;
                }
            }
            finally
            {
                serializersLock.ExitReadLock();
            }

            serializer = new DataContractJsonSerializer(type);

            serializersLock.EnterWriteLock();
            try
            {
                if (!serializersCache.ContainsKey(type))
                {
                    serializersCache.Add(type, serializer);
                }
                else
                {
                    serializer = serializersCache[type];
                }
            }
            finally
            {
                serializersLock.ExitWriteLock();
            }

            return serializer;
        }
    }
}
