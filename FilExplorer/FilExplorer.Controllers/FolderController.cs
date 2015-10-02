using FilExplorer.DataLayer.DAL;
using FilExplorer.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace FilExplorer.Controllers
{
    public class FolderController : Controller, IFolderController
    {
        private readonly IFolderContext FolderDB;

        public FolderController()
        {
            FolderDB=new FolderContext();
        }
        public FolderController(IFolderContext FolderDBContext)
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

        public void CreateNewFolderOnServer(string FolderPath)
        {
            throw new NotImplementedException();
        }

        public ActionResult CreateDefaultFolders(string UserID, List<string> FoldersNames)
        {
            foreach (string FolderName in FoldersNames)
            {
                FolderModel newFolder = new FolderModel()
                {
                    FolderID = Guid.NewGuid().ToString(),
                    Name = FolderName,
                    CreationDate = DateTime.Now,
                    ParentFolder = "",
                    UserId = UserID
                };
                if (ModelState.IsValid)
                {
                    FolderDB.Folders.Add(newFolder);
                    FolderDB.Commit();
                    var folderPath = UserID + @"\" + newFolder.Name;
                }
            }
            return View();
        }

        public string GetFolderPath(string folderID)
        {
            var folderPath = string.Concat(User.Identity.GetUserId(), "/",
                FolderDB.GetAllFolders.FirstOrDefault(s => s.FolderID == folderID).Name);
            return folderPath;
        }
       
       
    }
}