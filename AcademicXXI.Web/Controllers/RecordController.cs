using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademicXXI.Web.Controllers
{
    public class RecordController : Controller
    {
        // GET: Record
        public ActionResult Index()
        {
            return RedirectToAction("CreateRecord");
        }

        public ActionResult CreateRecord()
        {
            return View();
        }
    }
}