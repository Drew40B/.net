using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsolePlay.ef;
using ConsolePlay.log4netplay;

namespace ConsolePlay
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WindowWidth = 200;
          
            WriteWithColor("Starting...", ConsoleColor.Green);

            // IPlayable playable = new Log4NetPlay();
            //  IPlayable playable = new  ParamInfoPlay();
            //IPlayable playable = new UnityPlay.UnityPlay();
            //   IPlayable playable = new OldThreadException();
            // IPlayable playable = new DbPlay();
            //  IPlayable playable = new PathPlay();
            //  IPlayable playable = new HttpListenerPlay();
          //  IPlayable playable = new JsonPlay();
//          IPlayable playable = new UriPlay();
//var playable = new TasksPlay();

          //  IPlayable playable = new DatePlay();
            IPlayable playable = new EfPlay();

            try
            {
                if (!playable.Play())
                {
                    return;
                }
            }
            catch (Exception e)
            {
                WriteWithColor(e.ToString(),ConsoleColor.Red);
            }


            WriteWithColor("Done. Press the <any> key to continue",ConsoleColor.Green);
            Console.ReadKey();
        }

        public static void WriteWithColor(string message, ConsoleColor? forColor = null, ConsoleColor? backColor = null)
        {
            ConsoleColor prevFor = Console.ForegroundColor;
            ConsoleColor prevBack = Console.BackgroundColor;

            try
            {
                if (forColor != null)
                {
                    Console.ForegroundColor = forColor.Value;
                }

                if (backColor != null)
                {
                    Console.BackgroundColor = backColor.Value;
                }

                Console.WriteLine(message);
            }
            finally
            {
                Console.ForegroundColor = prevFor;
                Console.BackgroundColor = prevBack;
            }
        }
    }
}
