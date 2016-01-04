using FilExplorer.DataLayer.DAL;
using FilExplorer.DataLayer.Models;
using System;
using System.IO;
using System.Linq;
using System.Web;

namespace FilExplorer.Controllers
{
    public class FileController : IFileController
    {
        private IFileContext FileDB;
        private IFolderContext FolderDB;
  

        public FileController()
        {
            FileDB = new FileContext();
            FolderDB = new FolderContext();
        }
        public FileController(IFileContext FileDBContext,IFolderContext FolderDBContext)
        {
            FileDB = FileDBContext;
            FolderDB = FolderDBContext;
        }
        public void InsertFile(string fileName, string FolderID)
        {
            try
            {
                var query = FolderDB.GetAllFolders.FirstOrDefault(s => s.FolderID == FolderID);
                string folderName = query.Name;
                string userID = query.UserId;
                string bucketURL =
                    "https://s3.amazonaws.com/elasticbeanstalk-us-east-1-978940835697/FilExplorerWebSite/Uploads";
                FileModel filemodel = new FileModel()
                {
                    Name = fileName,
                    UploadDate = DateTime.Now,
                    FileID = Guid.NewGuid().ToString(),
                    //FilePath = string.Concat(bucketURL, "/", userID, "/", folderName.Replace(" ", "%20"), "/", fileName.Replace(" ", "%20")),
                    FilePath = string.Concat("../Uploads/", fileName.Replace(" ", "%20")),
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
