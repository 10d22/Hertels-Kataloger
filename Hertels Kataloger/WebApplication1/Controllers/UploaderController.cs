using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class UploaderController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Uploader()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Delete(string katalog)
        {
            string foldername = katalog;
            ViewBag.folder = foldername;

            string path = Server.MapPath("~/Content/Uploads/" + katalog + "/");
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }



            return Redirect("~/Home/");
        }


        [HttpPost]
        public ActionResult Uploader(List<HttpPostedFileBase> postedFiles, String name)
        {
            string path = Server.MapPath("~/Content/Uploads/" + name + "/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            foreach (HttpPostedFileBase postedFile in postedFiles)
            {
                if (postedFile != null)
                {
                    string fileName = Path.GetFileName(postedFile.FileName);
                    postedFile.SaveAs(path + fileName);
                    ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                }
            }


            return Redirect("~/Home/");
        }
    }
}