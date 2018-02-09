using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsolePlay
{
   public class JsonPlay : IPlayable
    {
        public class Result
        {
            public String Name { get; set; }
            public bool IsSuccess { get; set; }

            public int Count { get; set; }
        }
        public bool Play()
        {

            var results = new List<Result>()
            {
                new Result() {Count = 1, IsSuccess = true, Name = "One"},
                new Result() {Count = 2, IsSuccess = true, Name = "Two"},
                new Result() {Count = 3, IsSuccess = false, Name = "FREE!!!"}

            };

            String szJson = JsonConvert.SerializeObject(results,Formatting.Indented);
            Console.WriteLine(szJson);
           return true;
        }
    }
}
