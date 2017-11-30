using System.Collections.Generic;
using ProyectoNET_LocalDB.Models;

namespace ProyectoNET_LocalDB.Extra_Models
{
    public interface IFileRepository
    {
        IEnumerable<FileDescriptionShort> AddFileDescriptions(FileResult fileResult);

        IEnumerable<FileDescriptionShort> GetAllFiles();

        FileDescription GetFileDescription(int id);
    }
}
