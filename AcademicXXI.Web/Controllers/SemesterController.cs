using AcademicXXI.Domain;
using AcademicXXI.Services.SemesterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcademicXXI.ViewModel.MapExtensionMethod;
using System.Threading.Tasks;

namespace AcademicXXI.Web.Controllers
{
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
            return View(result.MapToSemesterViewModelListFromSemesterList());
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