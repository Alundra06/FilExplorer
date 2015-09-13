using FilExplorer.DataLayer.Models;
using System.Linq;
using System.Data.Entity;

namespace FilExplorer.DataLayer.DAL
{
    public class FolderContext: DbContext, IFolderContext
    {
        public FolderContext()
            : base("DefaultConnection")
        { }
        public IDbSet<FolderModel> Folders { get; set; }
        public void Commit()
        {
            base.SaveChanges();

        }
        public void DisposeOfObject()
        {
            base.Dispose();
        }

        //for testing purposes and Moq

        public IQueryable<FolderModel> GetAllFolders
        {
            get
            {
                return Folders;
            }
        }
    }
}
