using System;
using System.Threading.Tasks;

namespace LoggerAsync.Configs.Abstractions
{
    public interface ILoggerService
    {
        event Action<string, DateTime> MakeBackup;

        string Path { get; }

        Task WriteLog(string message);
    }
}
