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
            Guid studyPlanId;
            Guid.TryParse(StudyPIDStr, out studyPlanId);
            subject.Id = Guid.NewGuid();
            subject.StudyPID = studyPlanId;
            var subjectToSave = subject.MapToSubjectFromSubjectViewModel();
            subjectToSave.Created = DateTime.Now;
            subjectToSave.Status = Helpers.Status.Active;
            _serviceSubject.Add(subjectToSave);


            var result = await _serviceSubject.GetAllSubjectByStudyPlanAsync(StudyPCodeStr, studyPlanId);

            //return Json("All ok");
            return Json(result.MapToSubjectViewModelListFromSubjectList(), "application/json", Encoding.UTF8);
        }

        public async Task<ActionResult> SubjectRelation(string splancode, string splanid)
        {

            if (String.IsNullOrEmpty(splancode) || String.IsNullOrEmpty(splanid))
            {
                return RedirectToAction("Maintenance", "StudyPlan");
            }
            Guid splanidGuid;
            try
            {
                splanidGuid = Guid.Parse(splanid);
            }
            catch
            {
                return RedirectToAction("Maintenance", "StudyPlan");
            }


            var result = await _serviceSubject
                .GetAllSubjectByStudyPlanAsync(splancode, splanidGuid);

            var studyPlanViewModel = _serviceStudyPlan.Find(x => x.Id == splanidGuid).MapStudyPlanViewModelFromStudyPlan();

            if(studyPlanViewModel == null)
            {
                return RedirectToAction("Maintenance", "StudyPlan");
            }

            ViewBag.StudyPlanViewModelObj = studyPlanViewModel;


            return View(result.MapToSubjectViewModelListFromSubjectList());
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