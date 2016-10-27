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

namespace AcademicXXI.Web.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult Index()
        {
            return RedirectToAction("StudyPlan", "Index");
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Create(SubjectViewModel subject, string StudyPIDStr, string StudyPCodeStr)
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
            Int32 studyPlanId = Convert.ToInt32(StudyPIDStr);

            subject.StudyPID = studyPlanId;
            var subjectToSave = subject.GenericConvert<domain.Subject>();
            subjectToSave.Created = DateTime.Now;
            subjectToSave.Status = Helpers.Status.Active;
            _serviceSubject.Add(subjectToSave);


            var result = await _serviceSubject.GetAllSubjectByStudyPlanAsync(StudyPCodeStr, studyPlanId);

            //return Json("All ok");
            return Json(result.GenericConvertList<vm.SubjectViewModel>(), "application/json", Encoding.UTF8);
        }

        public async Task<ActionResult> SubjectRelation(string splancode, string splanid)
        {

            if (String.IsNullOrEmpty(splancode) || String.IsNullOrEmpty(splanid))
            {
                return RedirectToAction("Maintenance", "StudyPlan");
            }
            Int32 splanidGuid;
            try
            {
                splanidGuid = Convert.ToInt32(splanid);
            }
            catch
            {
                return RedirectToAction("Maintenance", "StudyPlan");
            }


            var result = await _serviceSubject
                .GetAllSubjectByStudyPlanAsync(splancode, splanidGuid);

            var studyPlanViewModel = _serviceStudyPlan.Find(x => x.Id == splanidGuid).GenericConvert<vm.StudyPlanViewModel>();

            if(studyPlanViewModel == null)
            {
                return RedirectToAction("Maintenance", "StudyPlan");
            }

            ViewBag.StudyPlanViewModelObj = studyPlanViewModel;


            return View(result.GenericConvertList<vm.SubjectViewModel>());
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