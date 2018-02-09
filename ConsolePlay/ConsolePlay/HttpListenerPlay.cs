using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlay
{
    public class HttpListenerPlay : IPlayable
    {
        private const string URL = "http://localhost:99/";

        public bool Play()
        {

            Task.Run(() => StartListener());

            Upload();
            return true;

        }

        private void StartListener()
        {
            var web = new HttpListener();

            web.Prefixes.Add(URL);

            Console.WriteLine($"Listening: {web.Prefixes.First()}");
            web.Start();

            var context = web.GetContext();

          
             using (StreamReader reader = new StreamReader(context.Request.InputStream))
            {
                string strbody = reader.ReadToEnd();

                using (var fs = new FileStream("c:/temp/out.txt", FileMode.Create))
                using (var writer = new StreamWriter(fs))
                {
                    writer.WriteLine("HEADERS");
                    foreach (string key in context.Request.Headers.AllKeys)
                    {
                        writer.WriteLine($"{key}: '{context.Request.Headers[key]}'");
                    }

                    writer.WriteLine("END HEADERS");
                    writer.WriteLine("");
                    writer.Write(strbody);
                }
                Console.Write(strbody);

            }

            const string responseString = "<html><body>Hello world</body></html>";

            var buffer = Encoding.UTF8.GetBytes(responseString);

            var response = context.Response;
            response.ContentLength64 = buffer.Length;
            var output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            web.Stop();
        }
        private string Upload()
        {
            var client = new HttpClient();
            var content = new MultipartFormDataContent();
            var requestParameters = new KeyValuePair<string, string>();

            using (FileStream fs = new FileStream(@"C:\temp\SIMPLE PDF.pdf", FileMode.Open))
            {
                content.Add(new StreamContent(fs),"File");
                //List<KeyValuePair<string, string>> b = new List<KeyValuePair<string, string>>();
                //b.Add(requestParameters);
                //var addMe = new FormUrlEncodedContent(b);
                //content.Add(addMe);

                content.Add(new StringContent("My JSON"),"Data");



                var result = client.PostAsync(URL, content);
                string strResult = result.Result.ToString();
                return strResult;
            }
        }
    }
}
