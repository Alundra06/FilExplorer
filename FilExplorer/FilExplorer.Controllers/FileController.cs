using FilExplorer.DataLayer.DAL;
using FilExplorer.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FilExplorer.Controllers
{
    class FileController
    {
        private IFileContext FileDB;
        private IFolderContext FolderDB;
        public FileController(IFileContext FileDBContext, IFolderContext FolderDBContext)
        {
            FileDB = FileDBContext;
            FolderDB = FolderDBContext;
        }
        public void UploadFileToServer(HttpPostedFileBase fileUpload, string FolderID)
        {
            try
            {
                FileModel filemodel = new FileModel()
                {

                    Name = Path.GetFileName(fileUpload.FileName),
                    UploadDate = DateTime.Now,
                    FileID = Guid.NewGuid().ToString(),
                    FolderID = FolderID,
                };


                    FileDB.Files.Add(filemodel);
                    FileDB.Commit();

                string TempLocationOnServer = System.AppDomain.CurrentDomain.BaseDirectory + @"Uploads\" + "FileName";
                fileUpload.SaveAs(TempLocationOnServer);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
