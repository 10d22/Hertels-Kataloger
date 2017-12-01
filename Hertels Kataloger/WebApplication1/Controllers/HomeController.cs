using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        /*public ActionResult Index()
        {
            return View();
        }
        */
        public ActionResult Katalog(string katalog) //   /Home/Katelog/?katelog=test
        {
            string test = katalog;
            ViewBag.folder = test;

            string path = HttpContext.Server.MapPath("~/Content/Uploads/" + test);
            DirectoryInfo di = new DirectoryInfo(path);
            int amountfiles = di.GetFiles().Length;
            ViewBag.pages = amountfiles;

            return View();
        }

        public ActionResult Index()
        {
            string path = HttpContext.Server.MapPath("~/Content/Uploads/");
            var di = new DirectoryInfo(path);
            var directories = di.EnumerateDirectories()
                                .OrderBy(d => d.CreationTime)
                                .Select(d => d.Name)
                                .ToList();
            /*string[] subfolders = System.IO.Directory.GetDirectories(path);*/

            directories.Reverse();

            ViewBag.folders = new List<string>();
            foreach (string subfolder in directories)
            {
                if (subfolder != null)
                {
                    /*DirectoryInfo dir = new DirectoryInfo(subfolder);*/
                    string folder = string.Format(subfolder);

                    ViewBag.folders.Add(folder);
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}