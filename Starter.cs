using System;
using System.Threading.Tasks;
using LoggerAsync.Services;
using LoggerAsync.Configs.Abstractions;

namespace LoggerAsync
{
    public class Starter
    {
        private ILoggerService _loggerService = new LoggerService();
        private IBackupService _backupService = new BackupService();
        public Logger Logger { get; set; }
        public FileService FileService { get; set; }

        public void Run()
        {
            var logFilepath = _loggerService.Path;
            _loggerService.MakeBackup += async (target, currentDaytime) =>
            {
                await _backupService.MakeBackup(target, currentDaytime);
            };

            Task.Run(() => FirstMethod());
            Task.Run(() => SecondMethod());
            Console.ReadKey();
        }

        private async void FirstMethod()
        {
            for (int i = 0; i < 50; i++)
            {
                await _loggerService.WriteLog($"This line was written from  {nameof(FirstMethod)}");
            }
        }

        private async void SecondMethod()
        {
            for (int i = 0; i < 50; i++)
            {
                await _loggerService.WriteLog($"This line was written from {nameof(SecondMethod)}");
            }
        }
    }
}
