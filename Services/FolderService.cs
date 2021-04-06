using System.IO;
using LoggerAsync.Configs.Abstractions;

namespace LoggerAsync.Services
{
    public class FolderService : IFolderService
    {
        public bool IsExists(string folderpath)
        {
            return Directory.Exists(folderpath);
        }

        public void MakeFolder(string folderpath)
        {
            Directory.CreateDirectory(folderpath);
        }

        public void MakeIfNot(string folderpath)
        {
            if (!IsExists(folderpath))
            {
                MakeFolder(folderpath);
            }
        }
    }
}
