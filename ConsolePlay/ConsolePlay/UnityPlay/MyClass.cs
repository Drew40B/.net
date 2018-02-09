using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlay.UnityPlay
{
   public  class MyClass
    {
        public MyLog Log { get; set; }

        public MyClass(MyLog log)
        {
            this.Log = log;
        }

        public void WriteLog()
        {
            Console.WriteLine(Log.MyType.ToString());
        }
    }
}
