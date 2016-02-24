using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.CSharp;

namespace FunctionCreator
{
    public class FunctionCreator
    {
        public static Func<double, double> F;

        /// <summary>
        /// Находит совпадения из строки в библиотеке Math
        /// </summary>
        /// <param name="s">Строка с функцией</param>
        /// <returns></returns>
        private static string GetName(string s)
        {
            return typeof(Math).GetMembers().First(m => m.Name.ToLower().Equals(s.ToLower())).Name;
        }

        /// <summary>
        /// Наличие функции, записанной в исходной строке в библиотеке Math
        /// </summary>
        /// <param name="f">Исходная строка с функцией</param>
        /// <returns></returns>
        private static bool HasFunc(string f)
        {
            return typeof(Math).GetMembers().Any(m => m.Name.ToLower().Equals(f.ToLower()));
        }

        /// <summary>
        /// Компилирует новую функцию для использования в коде
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static Assembly Compile(string code)
        {
            CodeDomProvider provider = new CSharpCodeProvider();
            CompilerParameters cp = new CompilerParameters
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
                IncludeDebugInformation = false
            };
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.Core.dll");
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, code);//CompileAssemblyFromFile(cp, "script.cs");
            if (!cr.Errors.HasErrors)
                return cr.CompiledAssembly;
            return null;
        }

        /// <summary>
        /// Создаёт программную функцию из формальной записи
        /// </summary>
        /// <param name="f">Текст функции</param>
        /// <returns></returns>
        public static Func<double, double> BuildFunc(string f)
        {
            f = Regex.Replace(f, @"(?<foo>\w+)", m => (HasFunc(m.Groups["foo"].Value) ? ("System.Math." + GetName(m.Groups["foo"].Value)) : m.Groups["foo"].Value));
            string funcdef = @"
            namespace __temp
            {{
              public class __class
              {{
                 public static double __func(double x)
                 {{
                    return {0};
                 }}
              }}
            }}";
            funcdef = string.Format(funcdef, f);
            Assembly ca = Compile(funcdef);
            Type[] t = ca.GetTypes();
            if (t.Length > 0)
            {
                MethodInfo mi = t[0].GetMethod("__func", BindingFlags.Static | BindingFlags.Public);
                if (mi == null) throw new Exception("error while compilation");
                return (Func<double, double>)Delegate.CreateDelegate(typeof(Func<double, double>), mi);
            }
            throw new Exception("error while compilation");
        }
    }
}
