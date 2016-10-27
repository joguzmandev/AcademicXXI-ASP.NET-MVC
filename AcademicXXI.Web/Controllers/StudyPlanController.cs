using AcademicXXI.Services.StudyPlanService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AcademicXXI.ViewModel.MapExtensionMethod;
using vm = AcademicXXI.ViewModel.ViewModel;
using domain = AcademicXXI.Domain;

namespace AcademicXXI.Web.Controllers
{
    public class StudyPlanController : Controller
    {
        // GET: StudenPlan
        public ActionResult Index()
        {
            return RedirectToAction("Maintenance");
        }

        public async Task<ActionResult> Maintenance()
        {
            var result = await _service.GetAllAsync();
            
            return View(result.GenericConvertList<vm.StudyPlanViewModel>());
        }

        public ActionResult Create(vm.StudyPlanViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Error en el modelo");

            }
            return Json("{Data:jlgshk}");
        }

        public StudyPlanController(IStudyPlanService service)
        {
            this._service = service;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _service.Dispose();
        }

        private readonly IStudyPlanService _service;

        
    }
}