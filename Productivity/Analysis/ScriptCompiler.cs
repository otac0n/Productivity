using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.CodeDom;

namespace Productivity.Analysis
{
    public sealed class ScriptCompiler
    {
        private static readonly CSharpCodeProvider compiler;
        private static readonly CompilerParameters options;

        static ScriptCompiler()
        {
            compiler = new CSharpCodeProvider();
            options = new CompilerParameters
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
            };
            options.ReferencedAssemblies.Add("System.dll");
            options.ReferencedAssemblies.Add("System.Core.dll");
            options.ReferencedAssemblies.Add("EventsLibrary.dll");
        }

        private static CodeCompileUnit FormatSource(string source, IList<Tuple<Type, string>> parameters, Type returnType)
        {
            var compileUnit = new CodeCompileUnit();
            var surrogateNamespace = new CodeNamespace("SurrogateNamespace");
            compileUnit.Namespaces.Add(surrogateNamespace);
            surrogateNamespace.Imports.Add(new CodeNamespaceImport("System"));
            surrogateNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            surrogateNamespace.Imports.Add(new CodeNamespaceImport("System.Linq"));
            surrogateNamespace.Imports.Add(new CodeNamespaceImport("System.Text"));
            var surrogateType = new CodeTypeDeclaration("SurrogateType");
            surrogateType.Attributes = MemberAttributes.Public | MemberAttributes.Static | MemberAttributes.Final;
            surrogateNamespace.Types.Add(surrogateType);
            var targetMethod = new CodeMemberMethod { Name = "ScriptMethod" };
            surrogateType.Members.Add(targetMethod);

            targetMethod.ReturnType = new CodeTypeReference(returnType);
            targetMethod.Attributes = MemberAttributes.Public | MemberAttributes.Static;
            foreach (var param in parameters)
            {
                targetMethod.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference(param.Item1), param.Item2));
            }
            targetMethod.Statements.Add(new CodeSnippetStatement(source));

            return compileUnit;
        }

        public MethodInfo CompileToMetod(string source, IList<Tuple<Type, string>> parameters, Type returnType)
        {
            var compilationUnit = FormatSource(source, parameters, returnType);

            var results = compiler.CompileAssemblyFromDom(options, compilationUnit);
            if (results.Errors.HasErrors)
            {
                throw new ScriptCompileFailedException(results.Errors.Cast<CompilerError>().ToArray(), results.Output.Cast<string>().ToArray());
            }

            var assembly = results.CompiledAssembly;
            var type = assembly.GetType("SurrogateNamespace.SurrogateType");
            var method = type.GetMethod("ScriptMethod");

            return method;
        }
    }
}
