using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MVCExample.Models;
namespace MVCExample.Controllers
{
    public class FileUploadController : Controller
    {
        Database1Entities db = new Database1Entities();
        // GET: FileUpload
        public ActionResult Index()
        {
            return View(db.tbl_upload.ToList());
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {

            

            file.SaveAs(Server.MapPath("/upload") + "/" + Path.GetFileName(file.FileName));
            tbl_upload t = new tbl_upload();
            t.imgname = Path.GetFileName(file.FileName);
            db.tbl_upload.Add(t);
            db.SaveChanges();
            ViewBag.data = "File Uploaded SuccessFully";
            return View(db.tbl_upload.ToList());
        }

       
    }
}
