using System.Collections.Generic;
namespace FilExplorer.Controllers
{
    public interface IFolderController
    {
        System.Web.Mvc.ActionResult CreateNewFolder(string FolderName, string ParentFolder, string UserID);
        void CreateNewFolderOnServer(string FolderPath);
        System.Web.Mvc.ActionResult CreateDefaultFolders(string UserID, List<string> FoldersNames);
    }
}
