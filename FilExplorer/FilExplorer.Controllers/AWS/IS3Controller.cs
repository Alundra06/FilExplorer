using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace FilExplorer.Controllers.AWS
{
    public interface IS3Controller
    {
        ActionResult UploadFileToS3(HttpPostedFileBase file, string folderName, string folderId);
        ActionResult CreateNewFolder(string folderName, string bucketPath);
       ActionResult CreateDefaultFolders(string UserID, List<string> FoldersNames);
    }
}