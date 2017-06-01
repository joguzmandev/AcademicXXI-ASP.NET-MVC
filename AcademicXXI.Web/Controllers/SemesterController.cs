using AcademicXXI.Domain;
using AcademicXXI.Services.SemesterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcademicXXI.ViewModel.MapExtensionMethod;
using System.Threading.Tasks;
using vm = AcademicXXI.ViewModel.ViewModel;
using domain = AcademicXXI.Domain;
using AcademicXXI.Web.Models;

namespace AcademicXXI.Web.Controllers
{
    [Authorize]
    public class SemesterController : Controller
    {
        // GET: Semester
        public ActionResult Index()
        {
            return RedirectToAction("Maintenance");
        }

        public async Task<ActionResult> Maintenance()
        {
            var result = await _semesterService.GetAllAsync();
            ViewBag.ListRangeYear = GetRangeYear();
            return View(result.GenericConvertList<vm.SemesterViewModel>());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(vm.SemesterViewModel semester)
        {
            Message msg = null;

            if (!ModelState.IsValid)
            {
                msg = new Message()
                {
                    Code = 0,
                    Messages = "Error, debe completar los campos",
                    Class = "label label-danger"
                };
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

            if (_semesterService.ExitSemesterCode(semester.SemesterCode))
            {
                msg = new Message()
                {
                    Code = 1,
                    Messages = "Código Académico ya exite",
                    Class = "label label-warning"
                };
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

            semester.Status = Helpers.Status.Active;
            semester.Created = DateTime.Now;
            _semesterService.Add(semester.GenericConvert<domain.Semester>());
            msg = new Message()
            {
                Code = 1,
                Messages = "Registro completado satisfactoriamente",
                Class = "label label-success"
            };
            return Json(msg,JsonRequestBehavior.AllowGet);
        }
        
        public async Task<ActionResult> GetAllSemester()
        {
            var result = await this._semesterService.GetAllAsync();

            return PartialView("_DisplayAllSemesters", result.GenericConvertList<vm.SemesterViewModel>());
        }

        private List<SelectListItem> GetRangeYear()
        {
            List<SelectListItem> years = new List<SelectListItem>();
            var lastYear = DateTime.Now.Year;
            years.Add(new SelectListItem() { Value = lastYear.ToString(), Text = lastYear.ToString() });
            for (var x=1;x < 15; x++)
            {
                var result = (--lastYear).ToString();
                years.Add(new SelectListItem() {
                    Value = result,
                    Text =result
                });
            }
            years.OrderByDescending(x => x.Text);
            return years;
        }


        public SemesterController(ISemesterService semesterService)
        {
            this._semesterService = semesterService;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _semesterService.Dispose();
        }

        private readonly ISemesterService _semesterService;
    }
}