using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.CSharp;

namespace Functions
{
    public class FunctionCreator
    {
        public static Func<double, double> f;

        /// <summary>
        /// Находит совпадения из строки в библиотеке Math
        /// </summary>
        /// <param name="s">Строка с функцией</param>
        /// <returns></returns>
        private static string getName(string s)
        {
            return typeof(Math).GetMembers().First(m => m.Name.ToLower().Equals(s.ToLower())).Name;
        }

        /// <summary>
        /// Наличие функции, записанной в исходной строке в библиотеке Math
        /// </summary>
        /// <param name="f">Исходная строка с функцией</param>
        /// <returns></returns>
        private static bool hasFunc(string f)
        {
            return typeof(Math).GetMembers().Any(m => m.Name.ToLower().Equals(f.ToLower()));
        }

        /// <summary>
        /// Компилирует новую функцию для использования в коде
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        static Assembly compile(string code)
        {
            CodeDomProvider provider = new CSharpCodeProvider();
            CompilerParameters cp = new CompilerParameters();
            cp.GenerateExecutable = false;
            cp.GenerateInMemory = true;
            cp.IncludeDebugInformation = false;
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.Core.dll");
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, code);//CompileAssemblyFromFile(cp, "script.cs");
            if (!cr.Errors.HasErrors)
                return cr.CompiledAssembly;
            else return null;
        }

        /// <summary>
        /// Создаёт программную функцию из формальной записи
        /// </summary>
        /// <param name="f">Текст функции</param>
        /// <returns></returns>
        public static Func<double, double> buildFunc(string f)
        {
            f = Regex.Replace(f, @"(?<foo>\w+)", m => (hasFunc(m.Groups["foo"].Value) ? ("System.Math." + getName(m.Groups["foo"].Value)) : m.Groups["foo"].Value));
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
            Assembly ca = compile(funcdef);
            Type[] t = ca.GetTypes();
            if (t.Length > 0)
            {
                MethodInfo mi = t[0].GetMethod("__func", BindingFlags.Static | BindingFlags.Public);
                if (mi == null) throw new Exception("error while compilation");
                try { return (Func<double, double>)Delegate.CreateDelegate(typeof(Func<double, double>), mi); }
                catch (Exception ex) { throw ex; }
            }
            else throw new Exception("error while compilation");
        }
    }
}
