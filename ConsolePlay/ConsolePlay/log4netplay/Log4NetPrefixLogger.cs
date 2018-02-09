using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Core;
using Newtonsoft.Json;

namespace ConsolePlay.log4netplay
{
    public class Log4NetPrefixLogger<T>
    {
        private ILog m_log;
        public Log4NetPrefixLogger()
        {
            m_log = LogManager.GetLogger(typeof(T));
        }

        public void Info(string message, string prefix)
        {
            LogIt(Level.Info, message,prefix);
        }

        public void Info(string message, Func<object> keyBuilder)
        {
            LogIt(Level.Info, message, keyBuilder);
        }
        public void Info(string message, dynamic keys)
        {
            LogIt(Level.Info, message, keys);
        }

        //public void Info(string message, dynamic keys)
        //{
        //    LogIt(Level.Info, message, keys);
        //}

        //public void Error(string message, dynamic keys)
        //{
        //    LogIt(Level.Error, message, keys);
        //}

        public void LogIt(Level level, string message,string prefix, Exception exception = null)
        {
            if (m_log.Logger.IsEnabledFor(level))
            {
                var szMessage = prefix + " " + message;

                m_log.Logger.Log(typeof(T), level, szMessage, exception);
            }
        }
        public void LogIt(Level level, string message, Func<object> keyBuilder, Exception exception = null)
        {
            if (m_log.Logger.IsEnabledFor(level))
            {
                var keys = keyBuilder();
                String szMessage = CreatePrefix(keys) + " " + message;

                m_log.Logger.Log(typeof(T), level, szMessage, exception);
            }
        }

        public void LogIt(Level level, string message, dynamic keys, Exception exception = null)
        {
            if (m_log.Logger.IsEnabledFor(level))
            {
                String szMessage = CreatePrefix(keys) + " " + message;

                m_log.Logger.Log(typeof(T), level, szMessage, exception);
            }
        }

        private string CreatePrefix(dynamic keys)
        {
            var builder = new StringBuilder();

            Type t = keys.GetType();

            foreach (var property in t.GetProperties())
            {
                builder.Append($"[{property.Name}:{property.GetValue(keys)}]");
            }


            return builder.ToString();
        }
    }
}
