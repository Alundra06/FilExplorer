using System;
namespace FilExplorer.Controllers
{
    public interface IFolderController
    {
        System.Web.Mvc.ActionResult CreateNewFolder(string FolderName, string ParentFolder, string UserID);
    }
}
