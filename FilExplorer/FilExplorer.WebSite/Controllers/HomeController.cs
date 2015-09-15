using FilExplorer.DataLayer.DAL;
using FilExplorer.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            IQueryable<FolderModel> fm = FolderDB.GetAllFolders;
           
            return View(fm);

        }
    }
}