using AcademicXXI.Services.SemesterService;
using AcademicXXI.Services.SubjectService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AcademicXXI.ViewModel.MapExtensionMethod;
using vm = AcademicXXI.ViewModel.ViewModel;
using domian = AcademicXXI.Domain;

namespace AcademicXXI.Web.Controllers
{
    public class RecordController : Controller
    {
        // GET: Record
        public ActionResult Index()
        {
            return RedirectToAction("CreateRecord");
        }

        public async Task<ActionResult> CreateRecord()
        {
            var result = await _semesterService.GetAllAsync();


            
            SelectList list = new SelectList(result.GenericConvertList<vm.SemesterViewModel>(), "SemesterCode", "SemesterCode");
            ViewBag.GetAllSemester = list;
            return View();
        }

        public async Task<ActionResult> GetAllSubject()
        {
           var result = await _subjectService.GetAllAsync();

            return Json(result.GenericConvertList<vm.SubjectViewModel>(),JsonRequestBehavior.AllowGet);
        }

        public RecordController(ISubjectService subjectService,ISemesterService semesterService)
        {
            this._subjectService = subjectService;
            this._semesterService = semesterService;
        }
        private ISubjectService _subjectService { get; set; }
        private ISemesterService _semesterService { get; set; }
    }
}