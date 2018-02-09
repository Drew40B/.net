using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlay
{
  public  class DatePlay : IPlayable
    {
        public bool Play()
        {
            var d = DateTime.Parse("Jan 1, 2017 00:30");

            Console.WriteLine(d);
            return true;
        }
    }
}
