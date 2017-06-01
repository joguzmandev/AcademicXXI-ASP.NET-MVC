using AcademicXXI.Services.SubjectService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AcademicXXI.ViewModel.MapExtensionMethod;
using AcademicXXI.Services.StudyPlanService;
using AcademicXXI.ViewModel.ViewModel;
using System.Net;
using System.Text;
using vm = AcademicXXI.ViewModel.ViewModel;
using domain = AcademicXXI.Domain;
using AcademicXXI.Web.Models;
using Newtonsoft.Json;
using System.Net.Mime;

namespace AcademicXXI.Web.Controllers
{
    [Authorize]
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult Index()
        {
            return RedirectToAction("StudyPlan", "Index");
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Create(SubjectViewModel subject, string StudyPCodeStr)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "FullError");
            }

            //Valid Subjec's code
            bool exitCode = this._serviceSubject.ExitCode(subject.Code);

            if (exitCode)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "CodeExit");
            }

            //Create Subject
            var subjectToSave = subject.GenericConvert<domain.Subject>();
            subjectToSave.StudyPlanFK = StudyPCodeStr;
            subjectToSave.Created = DateTime.Now;
            subjectToSave.Status = Helpers.Status.Active;
            _serviceSubject.Add(subjectToSave);

            var listOfSubjects = await _serviceSubject.GetAllSubjectByStudyPlanAsync(StudyPCodeStr);

            Message msg = new Message()
            {
                Code = 1,
                Messages = "Ok",
                list = listOfSubjects.GenericConvertList<vm.SubjectViewModel>()
            };


            return Json(ToJSON<Message>(msg), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> SubjectRelation(string splancode)
        {

            if (String.IsNullOrEmpty(splancode))
            {
                return RedirectToAction("Maintenance", "StudyPlan");
            }
           
            var studyPlanViewModel = _serviceStudyPlan.Find(x => x.Code == splancode).GenericConvert<vm.StudyPlanViewModel>();
            

            if(studyPlanViewModel == null)
            {
                return RedirectToAction("Maintenance", "StudyPlan");
            }

            ViewBag.StudyPlanViewModelObj = studyPlanViewModel;

            var result = await _serviceSubject
              .GetAllSubjectByStudyPlanAsync(splancode);
            
            return View(result.GenericConvertList<vm.SubjectViewModel>());
        }
                                        
        public async Task<ActionResult> GetAllSubjectRelation(string splancode)
        {

            var result = await _serviceSubject
                .GetAllSubjectByStudyPlanAsync(splancode);

            return PartialView("_DisplayAllSubjectRelation", result.GenericConvertList<vm.SubjectViewModel>());
        }

        private Object ToJSON<T>(T list)
        {
            return JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
        private readonly ISubjectService _serviceSubject;
        private readonly IStudyPlanService _serviceStudyPlan;

        public SubjectController(ISubjectService service, IStudyPlanService serviceStudyPlan)
        {
            this._serviceSubject = service;
            this._serviceStudyPlan = serviceStudyPlan;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._serviceSubject.Dispose();
        }
    }

  
}