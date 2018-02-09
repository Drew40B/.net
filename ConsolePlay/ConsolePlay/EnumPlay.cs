using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlay
{
    public class EnumPlay : IPlayable
    {
        private class A
        {
            public int Num { get; set; }
        }
        private enum MyPlay
        {
            A,B,C
        }
        public bool Play()
        {

            int num = 1;
            MyPlay p = (MyPlay) num;

            Console.WriteLine(p);

            num = 99;
            p = (MyPlay)num;
            Console.WriteLine(p);


            A a = null;
            Console.WriteLine(a?.Num == 10);


            return true;
        }
    }
}
