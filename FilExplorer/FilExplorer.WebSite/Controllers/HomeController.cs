using FilExplorer.DataLayer.DAL;
using FilExplorer.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FilExplorer.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private IFolderContext FolderDB;
        public HomeController(IFolderContext FolderDBContext)
        {
            FolderDB = FolderDBContext;    
        }
        public ActionResult Index()
        {
            return View();
            //return RedirectToAction("Login", "Account");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult ListFolders(string UserID)
        {
            var UserId = User.Identity.GetUserId();
            IQueryable<FolderModel> fm = FolderDB.GetAllFolders.Where(s => s.UserId == UserId);
           
            return View(fm);

        }
    }
}