using FilExplorer.DataLayer.DAL;
using FilExplorer.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FilExplorer.Controllers
{
    public class FolderController : Controller, IFolderController
    {
        private readonly IFolderContext FolderDB;
        public FolderController( IFolderContext FolderDBContext)
        {
            FolderDB = FolderDBContext;
        }
        public ActionResult CreateNewFolder(string FolderName, string ParentFolder, string UserID)
        {
                  
            FolderModel newFolder = new FolderModel()
            {
                FolderID = Guid.NewGuid().ToString(),
                Name = FolderName,
                CreationDate = DateTime.Now,
                ParentFolder = ParentFolder,
                UserId = UserID
            };
            if (ModelState.IsValid)
            {
                FolderDB.Folders.Add(newFolder);
                FolderDB.Commit();
            }
            return View();
        }
    }
}