using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Productivity.Analysis
{
    public delegate dynamic ScriptFunc(DateTime time, DateTime startTime, DateTime endTime);

    public static class ScriptManager
    {
        private static ScriptCompiler compiler = new ScriptCompiler();

        private static ReaderWriterLockSlim @lock = new ReaderWriterLockSlim();

        private static Dictionary<string, ScriptFunc> cache = new Dictionary<string, ScriptFunc>();

        private static readonly Tuple<Type, string>[] scriptArguments =
        {
            Tuple.Create(typeof(DateTime), "time"),
            Tuple.Create(typeof(DateTime), "startTime"),
            Tuple.Create(typeof(DateTime), "endTime"),
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
            return (time, startTime, endTime) =>
            {
                return methodInfo.Invoke(null, new object[] { time, startTime, endTime });
            };
        }
    }
}
