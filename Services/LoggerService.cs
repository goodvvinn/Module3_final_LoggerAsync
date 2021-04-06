using System;
using System.Threading.Tasks;
using LoggerAsync.Configs;
using LoggerAsync.Configs.Abstractions;

namespace LoggerAsync.Services
{
    public class LoggerService : ILoggerService
    {
        private string _toLogFile;
        private int _logCounter;
        private int _backupPeriod;
        private IFileService _fileService;
        private IConfigService _configService;
        private LoggerConfig _loggerconfig;

        // private static SemaphoreSlim sem = new SemaphoreSlim(1);
        public LoggerService()
        {
            _configService = new ConfigService();
            _loggerconfig = _configService.GetConfiguration();
            _fileService = new FileService();
            _backupPeriod = Convert.ToInt32(_loggerconfig.BackupPeriod);
            Run();
        }

        public event Action<string, DateTime> MakeBackup;

        public string Path => _toLogFile;

        public async Task WriteLog(string mes)
        {
            var logMessage = $"{DateTime.UtcNow}: {mes}";
            await _fileService.MyStreamWriterAsync(_toLogFile, mes);
            _logCounter++;
            Response();
        }

        private void Response()
        {
            if (_logCounter % _backupPeriod == 0)
            {
                var chrono = DateTime.UtcNow;
                Console.WriteLine($"Backup iteration: {chrono}");
                MakeBackup?.Invoke(_toLogFile, chrono);
            }
        }

        private void Run()
        {
            var dtView = DateTime.UtcNow.ToString(_loggerconfig.DayTimeFormat);
            _toLogFile = $@"{_loggerconfig.LogsDir}{_loggerconfig.FileExtension}";
        }
    }
}
