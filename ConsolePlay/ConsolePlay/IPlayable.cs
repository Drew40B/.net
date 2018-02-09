using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlay
{
    public interface IPlayable
    {
        /// <summary>
        /// Method to play with
        /// </summary>
        /// <returns>true to pause the console and wait for a key to be pressed</returns>
       bool Play();
    }
}
