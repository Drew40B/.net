using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsolePlay
{
    public class UriPlay : IPlayable
    {
        public bool Play()
        {
            var uri = new Uri("http://myServer.com/v1/cmas/a1/1/B2/2?Parm1=p1Parm2=P2");
            Console.WriteLine(uri.ToString());

            string szOut = string.Join("", uri.Segments.Skip(3).Where(seg => Regex.IsMatch(seg,@"^\D+") ));
            Console.WriteLine(szOut);

            return true;
        }
    }
}
