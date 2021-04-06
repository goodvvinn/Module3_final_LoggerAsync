using System.Threading.Tasks;

namespace LoggerAsync.Configs.Abstractions
{
    public interface IFileService
    {
        Task MyStreamWriterAsync(string path, string message);
        Task Copy(string source, string target);
    }
}
