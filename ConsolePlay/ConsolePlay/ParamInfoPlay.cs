using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlay
{
   public  class ParamInfoPlay : IPlayable
    {
        public bool Play()
        {
            Method1(22,"My String parm that is realllllllllly Lonnnnnnnnnnnnnnnnnnnng");
            return true;
        }

        public void Method1(int i, String s)
        {
            LogIt(i,s);
        }

        public void LogIt(params object[] values)
        {
            StackTrace stackTrace = new StackTrace();

            var methodParms = stackTrace.GetFrame(1).GetMethod().GetParameters();
            StringBuilder message = new StringBuilder();

            int iParmCount = Math.Min(values.Length, methodParms.Length);
            for (int x = 0; x < iParmCount; x++)
            {
                StringBuilder value = new StringBuilder(values[x].ToString());
                bool bTruncated = false;

                while (value.Length > 30)
                {
                    value.Remove(15, 5);
                    bTruncated = true;
                }

                if (bTruncated)
                {
                    value.Insert(15, "...");
                }

                message.Append($"[{methodParms[x].Name}:'{value}' ({values[x].GetType().Name})]");
            }
        
            Console.WriteLine(message.ToString());

        }
    }
}
