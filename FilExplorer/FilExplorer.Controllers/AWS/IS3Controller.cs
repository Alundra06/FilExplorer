using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace FilExplorer.Controllers.AWS
{
    public interface IS3Controller
    {
        void UploadFileToS3(HttpPostedFileBase file, string folderName, string folderID);
        ActionResult CreateNewFolder(string folderName, string bucketPath);
        System.Web.Mvc.ActionResult CreateDefaultFolders(string UserID, List<string> FoldersNames);
    }
}