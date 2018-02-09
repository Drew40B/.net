using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlay.MethodInfo
{
   public  class MethodInfo
    {
        public String MethodName { get; set; }

        public Dictionary<string,object> Parameters { get; set; }

        public void AddParameter(string name, object value)
        {
            if (Parameters == null)
            {
                Parameters = new Dictionary<string, object>();
            }

            Parameters.Add(name,value);
        }

        public string ToLog()
        {
            var writer = new StringWriter();

            writer.Write(MethodName);
            writer.Write("(");

            foreach (var parameter in Parameters)
            {
                writer.Write(parameter.Key);
                writer.Write("= ' '");
            }

            return writer.ToString();

        }
    }
}
