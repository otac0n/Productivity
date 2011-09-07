using System;
using System.Collections.Generic;
using System.Threading;
using EventsLibrary;

namespace Productivity.Analysis
{
    public delegate dynamic ScriptFunc(DateTime startTime, DateTime endTime, IList<EventData> events);

    public static class ScriptManager
    {
        private static ScriptCompiler compiler = new ScriptCompiler();

        private static ReaderWriterLockSlim @lock = new ReaderWriterLockSlim();

        private static Dictionary<string, ScriptFunc> cache = new Dictionary<string, ScriptFunc>();

        private static readonly Tuple<Type, string>[] scriptArguments =
        {
            Tuple.Create(typeof(DateTime), "startTime"),
            Tuple.Create(typeof(DateTime), "endTime"),
            Tuple.Create(typeof(IList<EventData>), "events"),
        };

        public static ScriptFunc GetScriptFunc(string source)
        {
            ScriptFunc result;
            bool found;

            @lock.EnterReadLock();
            try
            {
                found = cache.TryGetValue(source, out result);
            }
            finally
            {
                @lock.ExitReadLock();
            }

            if (found)
            {
                return result;
            }

            @lock.EnterWriteLock();
            try
            {
                found = cache.TryGetValue(source, out result);
                if (found)
                {
                    return result;
                }

                result = Compile(source);
                cache.Add(source, result);
                return result;
            }
            finally
            {
                @lock.ExitWriteLock();
            }
        }

        private static ScriptFunc Compile(string source)
        {
            var methodInfo = compiler.CompileToMetod(source, scriptArguments, typeof(object));
            return (startTime, endTime, events) =>
            {
                return methodInfo.Invoke(null, new object[] { startTime, endTime, events });
            };
        }
    }
}
