using System;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using LoggerAsync.Configs.Abstractions;
using LoggerAsync.Configs;

namespace LoggerAsync.Services
{
    public class FileService : IFileService
    {
        private readonly IFolderService _folderService;
        private readonly IConfigService _configService;
        private readonly LoggerConfig _config;
        private StreamWriter _streamWriter;

        private static SemaphoreSlim semafSlim = new (1);
        public FileService()
        {
            _folderService = new FolderService();
            _configService = new ConfigService();
            _config = _configService.GetConfiguration();

            _folderService.MakeIfNot(_config.BackupPath);
        }

        public async Task MyStreamWriterAsync(string path, string text)
        {
            await semafSlim.WaitAsync();

            using (FileStream stream = File.OpenWrite(path))
            {
                using (_streamWriter = new StreamWriter(stream, Encoding.Default))
                {
                    await _streamWriter.WriteLineAsync(text);
                }
            }

            semafSlim.Release();
        }

        public async Task Copy(string sourceFile, string destinationFile)
        {
            await semafSlim.WaitAsync();
            try
            {
                File.Copy(sourceFile, destinationFile);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }

            semafSlim.Release();

            // return await tcs.Task;
        }
    }
}
