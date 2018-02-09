using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsolePlay
{
    class OldThreadException : IPlayable
    {
        public bool Play()
        {

            bool bCaught = false;
            try
            {
                Thread t = new Thread(MyMethod);
                t.Start();
                t.Join();


            }
            catch (Exception ex)
            {
                bCaught = true;
              Console.WriteLine(ex.ToString());  
            }
           
            Console.WriteLine($"Exception caught: {bCaught}");
            return true;
        }


        private void MyMethod()
        {
            throw new Exception("I am here!!!");
        }
    }
}
