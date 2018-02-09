using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardManipulation
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var contents = Clipboard.GetData("Text")?.ToString();

            if (contents != null)
            {
                contents = contents.Replace(";", "").Replace(",","").Replace("=", ",");

                StringWriter writer = new StringWriter();
                using (var reader = new StringReader(contents))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        var sections = line.Split(',');
                        if (sections.Length == 2)
                        {
                            writer.WriteLine($"Assert.Equal({sections[1].Trim()},{sections[0].Trim()});");
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                        line = reader.ReadLine();
                    }

                   
                }

                Clipboard.SetData("Text",writer.ToString());
            }
           
        }
    }
}
