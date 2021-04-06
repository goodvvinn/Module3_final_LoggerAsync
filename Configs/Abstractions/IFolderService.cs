namespace LoggerAsync.Configs.Abstractions
{
    public interface IFolderService
    {
        bool IsExists(string path);

        void MakeFolder(string path);

        void MakeIfNot(string path);
    }
}
