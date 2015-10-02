using FilExplorer.DataLayer.DAL;
using FilExplorer.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Configuration;

namespace FilExplorer.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private IFolderContext FolderDB;
        private IFileContext FileDB;
        public HomeController(IFolderContext FolderDBContext, IFileContext FileDBContext)
        {
            FolderDB = FolderDBContext;
            FileDB = FileDBContext;
        }
        public ActionResult Index()
        {
            return View();
            //return RedirectToAction("Login", "Account");
        }

        public ActionResult About()
        {
            return RedirectToAction("CreateNewFolderOnServer", "Folder");
        }
        public ActionResult ListFolders()
        {
            var UserId = User.Identity.GetUserId();
            IQueryable<FolderModel> fm = FolderDB.GetAllFolders.Where(s => s.UserId == UserId);
            //var ss = fm.FirstOrDefault().Files;
           
            return View(fm);

        }

        public ActionResult ListFiles(string folderID)
        {

            IQueryable<FileModel> fileModel = FileDB.GetAllFiles.Where(s => s.FolderID == folderID);
            //var ss = fm.FirstOrDefault().Files;

            return View(fileModel);

        }
    }
}