using System;
using ConsolePlay.log4netplay;
using log4net.Core;

namespace ConsolePlay.log4netplay
{
  public  class Log4NetPlay : IPlayable
    {
        //public bool Play()
        //{
        //   var wrapper = new Log4NetWrapper<Log4NetPlay>("MyKey");
           
        //    wrapper.Info("MyMessage",new {dealid = "12343",filename=@"c:\temp"});

        //    LogSpecificState state = new LogSpecificState()
        //    {
        //        DealId = "DDD",
        //        Key = "MyKey"
        //    };

        //    wrapper.LogIt(Level.Info,"My State",state);


        //    LogError err = new LogError()
        //    {
        //        Dealid = "12345",
        //        Ex = new Exception("This is bad")
        //    };

        //wrapper.Error("Some thing happened!",err);

        //    return true;
        //}


        public class MyClass
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
        public bool Play()
        {
            var log = new Log4NetPrefixLogger<Log4NetPlay>();

            int iProcessId = 10;
            string myKey = "The other Key";

            Func<object> keyBuilder = () => new {ProcessId = iProcessId, Key = myKey};
              
            log.Info("Test",keyBuilder );


            var me = new MyClass() {Name = "Herb", Value = 99};

            log.Info("Hello",new {me.Name,me.Value});

            return true;
        }
    }
}
