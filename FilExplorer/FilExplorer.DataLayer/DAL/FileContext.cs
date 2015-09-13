using FilExplorer.DataLayer.Models;
using System.Data.Entity;
using System.Linq;

namespace FilExplorer.DataLayer.DAL
{
    class FileContext:DbContext,IFileContext
    {
        public FileContext()
            : base("DefaultConnection")
        {
        }
        public virtual IDbSet<FileModel> Files { get; set; }

        public IDbSet<FolderModel> FolderModels { get; set; }

        public void Commit()
        {
            base.SaveChanges();
        }
        public void DisposeOfObject()
        {
            base.Dispose();
        }

        //for testing purposes and Moq

        public IQueryable<FileModel> GetAllFiles
        {
            get
            {
                return Files;
            }
        }
    }
}
