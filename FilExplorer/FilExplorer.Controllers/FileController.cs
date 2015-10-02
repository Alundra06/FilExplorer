using FilExplorer.DataLayer.DAL;
using FilExplorer.DataLayer.Models;
using System;
using System.IO;
using System.Web;

namespace FilExplorer.Controllers
{
    public class FileController : IFileController
    {
        private IFileContext FileDB;
  

        public FileController()
        {
            FileDB = new FileContext();
        }
        public FileController(IFileContext FileDBContext)
        {
            FileDB = FileDBContext;
        }
        public void InsertFile(string fileName, string FolderID)
        {
            try
            {
                FileModel filemodel = new FileModel()
                {
                    Name = fileName,
                    UploadDate = DateTime.Now,
                    FileID = Guid.NewGuid().ToString(),
                    FolderID = FolderID,
                };


                    FileDB.Files.Add(filemodel);
                    FileDB.Commit();
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
