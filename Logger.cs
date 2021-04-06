using System;
using LoggerAsync.Configs;

namespace LoggerAsync
{
    public class Logger
   {
        public Logger()
        {
            Report = string.Empty;
        }

        public string Report { get; set; }
        public void Save(Result result)
        {
             string mess = "This is a result of the:" + result.Message;
             Report += DateTime.Now.ToString("h:mm:ss\t") + result.Message;
        }
    }
}
