using FilExplorer.DataLayer.DAL;
using FilExplorer.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;


namespace FilExplorer.Controllers
{
    public class FolderController : Controller, IFolderController
    {
        private readonly IFolderContext FolderDB;
        private readonly IFileSystem FileSystem;
        public FolderController(IFolderContext FolderDBContext, IFileSystem fileSystem)
        {
            FolderDB = FolderDBContext;
            FileSystem = fileSystem;
        }
        public FolderController()
        {

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
                    CreateNewFolderOnServer(folderPath);
                }
            }
            return View();
        }
        public void CreateNewFolderOnServer(string FolderPath)
        {
            //string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, FolderPath);
            //Directory.CreateDirectory(filePath);
            string pathToCreate = "~/Uploads/";
            if (Directory.Exists(HostingEnvironment.MapPath("~/uploads")))
            {
                var cc= "jhgd";

            }

            //Now you know it is ok, create it
            Directory.CreateDirectory(FolderPath);

        }
       
    }
}