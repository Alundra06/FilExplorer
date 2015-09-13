using FilExplorer.DataLayer.Models;
using System.Linq;

namespace FilExplorer.DataLayer.DAL
{
    public interface IFileContext
    {
        void Commit();
        void DisposeOfObject();
        System.Data.Entity.IDbSet<FileModel> Files { get; set; }
        System.Data.Entity.IDbSet<FolderModel> FolderModels { get; set; }

        //For testing purposes
        IQueryable<FileModel> GetAllFiles { get; }
    }
}
