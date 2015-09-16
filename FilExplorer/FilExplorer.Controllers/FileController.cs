using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FilExplorer.Controllers
{
    class FileController
    {
        public FileModel UploadFileToServer(HttpPostedFileBase fileUpload, string Parent_Folder2, string LoggedInUserID, string TaskID)
        {
            //Check the Parent Folder value
            if (Parent_Folder2 == "" || FolderDB.GetAllFolders.Where(s => s.FolderID == Parent_Folder2).Any() == false)
            {
                //choose The ID of the root folder if no folder is selected
                Parent_Folder2 = FolderDB.GetAllFolders.Where(s => s.Type == "Root").First().FolderID;
            }
            else //check if a file is seletcted
            {

                if (FileDB.Files.Any(a => a.FileID == Parent_Folder2))
                {
                    Parent_Folder2 = FileDB.Files.Find(Parent_Folder2).FolderID;
                }

            }

            /////////////////////////////////////////////////////////////////////////////
            //////////////End of checking folder ID ////////////////////////////////////



            if (fileUpload != null)
            {


                //taction = "Index";
                //tcontroller = "File";




                //to store the full path of the file for the file system
                string FolderFullPath = FolderDB.Folders.Find(Parent_Folder2).FullPath;

                //to store the relative server full path of the file

                //string FileFullPath1 = Server.MapPath(@"\Uploads" + @FolderFullPath);
                //string FileFullPath = Path.Combine(FileFullPath1, Path.GetFileName(fileUpload.FileName));


                FileModel filemodel = new FileModel()
                {

                    UserIdd = LoggedInUserID,
                    Name = Path.GetFileName(fileUpload.FileName),
                    UploadDate = DateTime.Now,
                    // FilePath = FileFullPath,
                    FolderPath = FolderFullPath,
                    FileID = Guid.NewGuid().ToString(),
                    FolderID = Parent_Folder2,
                    TasksID = TaskID

                };

                if (ModelState.IsValid)
                {
                    FileDB.Files.Add(filemodel);
                    FileDB.Commit();
                }


                //TODO this is the part where i made decision to save to a temp position 
                //Under the uploads files instead of the server
                //Upload the file to the hosted server location

                //fileUpload.SaveAs(FileFullPath);
                //string ss = System.AppDomain.CurrentDomain.BaseDirectory;
                //string TempLocationOnServer = Server.MapPath(@"\Uploads\" + filemodel.Name);
                string TempLocationOnServer = System.AppDomain.CurrentDomain.BaseDirectory + @"Uploads\" + filemodel.Name;
                fileUpload.SaveAs(TempLocationOnServer);

                //Upload a copy to the DropBox account
                //return RedirectToAction("UploadFile", "DropBox", new { FolderName = FolderFullPath, FilePath = filemodel.FilePath, Faction = "Index", Fcontroller = "Folder" });
                return filemodel;
            }

            //something went wrong : display The index again
            else
                return null;
        }
    }
}
