using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlay
{
    public class PathPlay :IPlayable
    {
        public bool Play()
        {
            string szPath =@"\\MCAP11.MCAP.COM\5541k\Nova\Packages\13498\Backup\DEV\Platform\Include\Functions\Ingestion\IngestionProcess.php";
            string szDir = Path.GetDirectoryName(szPath);
            Console.WriteLine(szDir);
            szDir = Path.GetDirectoryName(szDir);
            Console.WriteLine(szDir);

            return true;

        }
    }
}
