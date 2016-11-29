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
using AcademicXXI.Web.Models;
using Newtonsoft.Json;
using System.Net;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(vm.StudyPlanViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Message msgError = new Message() {
                     Code =0,
                     Messages = "Error, debe completar los campos",
                     Class = "label label-danger"
                };
                return Json(msgError, JsonRequestBehavior.AllowGet);
            }

            if (String.IsNullOrEmpty(model.Code))
            {
                Message msgError = new Message()
                {
                    Code = 1,
                    Messages = "Debe ingresar un código",
                    Class = "label label-danger"
                };
                return Json(msgError, JsonRequestBehavior.AllowGet);
            }

            if (this._service.ExitStudyPlan(model.Code))
            {
                Message msgError = new Message()
                {
                    Code = 2,
                    Messages = "Código ya existe",
                    Class = "label label-warning"
                };

                return Json(msgError, JsonRequestBehavior.AllowGet);
            }

            if (String.IsNullOrEmpty(model.Name))
            {
                Message msgError = new Message()
                {
                    Code = 3,
                    Messages = "Debe ingresar un nombre",
                    Class = "label label-danger"
                };
                return Json(msgError,JsonRequestBehavior.AllowGet);
            }

            domain.StudyPlan splan = model.GenericConvert<domain.StudyPlan>();
            splan.Status = Helpers.Status.Active;
            splan.Created = DateTime.Now;
            this._service.Add(splan);

            Message msgSuccess = new Message()
            {
                Code = 4,
                Messages = "Plan de estudio creado satisfactoriamente",
                Class = "label label-success"
            };

            return Json(msgSuccess, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> AllStudyPlans()
        {
            var result = await _service.GetAllAsync();

            return PartialView("_DisplayAllStudyPlan", result.GenericConvertList<vm.StudyPlanViewModel>());
        }

        private Object ToJSON(List<vm.StudyPlanViewModel> list)
        {
            return JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
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