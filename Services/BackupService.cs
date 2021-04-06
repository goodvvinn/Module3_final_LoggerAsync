using System;
using System.Threading.Tasks;
using LoggerAsync.Configs.Abstractions;
using LoggerAsync.Configs;

namespace LoggerAsync.Services
{
    public class BackupService : IBackupService
    {
        private IFolderService _folderService;
        private IFileService _fileService;
        private IConfigService _configService;
        private LoggerConfig _loggerconfig;

        public BackupService()
        {
            _folderService = new FolderService();
            _fileService = new FileService();
            _configService = new ConfigService();
            _loggerconfig = _configService.GetConfiguration();

            CreateBackupDir();
        }

        public async Task MakeBackup(string path, DateTime dt)
        {
            var dtview = dt.ToString("HH.mm.ss.ff");
            var backupFilename = $@"{_loggerconfig.LogsDir}\{dtview}{_loggerconfig.FileExtension}";

            await _fileService.Copy(path, backupFilename);
        }

        public void CreateBackupDir()
        {
            _folderService.MakeIfNot(_loggerconfig.BackupPath);
        }
    }
}
