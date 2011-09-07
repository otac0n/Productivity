using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;

namespace Productivity.Analysis
{
    public class ScriptCompileFailedException : Exception
    {
        private readonly IList<CompilerError> errors;
        private readonly IList<string> messages;

        public ScriptCompileFailedException(CompilerError[] errors, string[] messages)
        {
            this.errors = errors.ToList().AsReadOnly();
            this.messages = messages.ToList().AsReadOnly();
        }

        public IList<CompilerError> Errors
        {
            get
            {
                return this.errors;
            }
        }

        public IList<string> Messages
        {
            get
            {
                return this.messages;
            }
        }
    }
}
