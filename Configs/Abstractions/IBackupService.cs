using System;
using System.Threading.Tasks;

namespace LoggerAsync.Configs.Abstractions
{
    public interface IBackupService
    {
        Task MakeBackup(string path, DateTime dt);
    }
}
