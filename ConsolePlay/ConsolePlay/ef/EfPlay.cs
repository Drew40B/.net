using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsolePlay.ef.poco;

namespace ConsolePlay.ef
{
   public class EfPlay :IPlayable
    {
        public bool Play()
        {
            var context = new PlayContext();

            var a1 = new AssociatedAlloc()
            {
                Name = "A1"
            };

            var a2 = new AssociatedAlloc()
            {
                Name = "A2"
            };

            context.AssociatedAllocs.Add(a1);
            context.AssociatedAllocs.Add(a2);

        //   context.SaveChanges();

            a1.Associated = a2;
         //   a2.Associated = a1;


       
            context.SaveChanges();

            return true;
        }
    }
}
