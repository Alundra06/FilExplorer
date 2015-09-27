using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FilExplorer.Controllers
{
    class FileController
    {
        public ActionResult UploadFileToServer(HttpPostedFileBase fileUpload, string ParentFolder)
        {

            if (fileUpload != null)
            {
                string TempLocationOnServer = System.AppDomain.CurrentDomain.BaseDirectory + @"Uploads\" + "FileName";
                fileUpload.SaveAs(TempLocationOnServer);
            }

        }
    }
}
