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
    public class Log4NetWrapper<T>
    {
        private ILog m_log;
        private string m_key;
        public Log4NetWrapper(string key)
        {
            m_log = LogManager.GetLogger(typeof(T));
            m_key = key;
        }


        public void Info(string dealId, string filename, string message)
        {
            if (m_log.IsInfoEnabled)
            {
                dynamic keys = new
                {
                    Transaction = m_key,
                    dealId = dealId,
                    message = message
                };

                LogIt(Level.Info, message,keys);
            }
        }

        public void Info(string message, dynamic keys)
        {
            LogIt(Level.Info,message,keys);
        }

        public void Error(string message, dynamic keys)
        {
            LogIt(Level.Error, message, keys);
        }

        public void LogIt(Level level, string message, dynamic keys,Exception exception = null)
        {
            if (m_log.Logger.IsEnabledFor(level))
            {
                String szMessage =$"B3G1NJ0N{JsonConvert.SerializeObject(keys)}3NDJS0N {message}";

                m_log.Logger.Log(typeof(T), level, szMessage, exception);
            }
        }

    }
}
