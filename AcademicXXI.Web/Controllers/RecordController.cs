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
using AcademicXXI.Services.RecordService;
using AcademicXXI.Web.Models;
using System.Data.SqlClient;
using Newtonsoft.Json;
using AcademicXXI.Services.ProfessorService;

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
            
            SelectList list = new SelectList(result.GenericConvertList<vm.SemesterViewModel>(), "SemesterCode", "DisplaySemesterDescription");
            ViewBag.GetAllSemester = list;
            return View();
        }

        [HttpPost]
        public JsonResult CreateRecord(String SAcademicYear,String selectAddSubject)
        {
            Message msg = null;
            if (String.IsNullOrEmpty(SAcademicYear))
            {
                msg = new Message()
                {
                    Code = 0,
                    Class = "alert alert-danger",
                    Messages = "Debe seleccionar el Año Académico",
                    Status = false
                };

                return Json(msg, JsonRequestBehavior.AllowGet);
            }

            if (String.IsNullOrEmpty(selectAddSubject))
            {
                msg = new Message()
                {
                    Code = 0,
                    Class = "alert alert-danger",
                    Messages = "Debe seleccionar una asignatura",
                    Status = false
                };
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            
            if (_recordService.ExitRecord(SAcademicYear, selectAddSubject))
            {
                msg = new Message()
                {
                    Code = 0,
                    Class = "alert alert-danger",
                    Messages = "La asignatura seleccionada ya está registrada para el semestre seleccionado",
                    Status = false
                };
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

            var record = new domian.Record() {
                SemesterFK = SAcademicYear,
                SubjectFK = selectAddSubject,
                Created = DateTime.Now,
                Status = Helpers.Status.Active
            };
            try
            {
                _recordService.Add(record);
            }catch(Exception e)
            {
                var result = e.InnerException.InnerException.Message.Contains("Violation of PRIMARY KEY constraint");
                if (result)
                {
                    msg = new Message()
                    {
                        Code = -1,
                        Class = "alert alert-danger",
                        Messages = "La asignatura seleccionada está ya registrada para el periodo seleccionado",
                        Status = false

                    };
                    return Json(msg, JsonRequestBehavior.AllowGet);

                }
               
            }
            msg = new Message()
            {
                Code = 1,
                Class = "alert alert-success",
                Messages = "Acta creada satisfactoriamente",
                Status = true
            };
            return Json(msg,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //TODO Pending to validate
        public JsonResult AddSessionRecord(
            String subject,String semester,String NumericSession,
            String SessionDescription,String LimitSession,String Professor)
        {
            //Get Record
            var record = _recordService.Find(r => r.SubjectFK.Equals(subject) && r.SemesterFK.Equals(semester));
            if(record == null)
            {
                Message msg = new Message()
                {
                    Class = "alert alert-danger",
                    Messages = "Error",
                    Code = -1
                };
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

            var recordDetail = new domian.RecordDetails()
            {
                SubjectFK = record.SubjectFK,
                SemesterFK = record.SemesterFK,
                NumericSession = Int32.Parse(NumericSession),
                SessionDescription = SessionDescription,
                LimitSession = Int32.Parse(LimitSession),
                ProfessorFK = String.IsNullOrEmpty(Professor)?null:Professor,
                Status = Helpers.Status.Active,
                Created = DateTime.Now,
            };
            record.RecordDetails.Add(recordDetail);
            try {
                _recordService.Update(record);
            } catch (Exception e)
            {
                if (e.InnerException.InnerException.Message.Contains("Cannot insert duplicate key row in object "))
                {
                    Message msg = new Message()
                    {
                        Class = "alert alert-danger",
                        Messages = "La sección ya existe en la base de datos",
                        Code = -1
                    };
                    return Json(msg, JsonRequestBehavior.AllowGet);
                }
            }
           


            return Json(new Message() {
                Class = "alert alert-success",
                Messages = "Sección registrada satisfactoriamente" }
            ,JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetAllSubject()
        {
           var result = await _subjectService.GetAllAsync();

            return Json(result.GenericConvertList<vm.SubjectViewModel>(),JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSemesterSubjects(String semesterCode)
        {
            var result = _semesterService.GetSemesterSubjects(semesterCode).GenericConvert<vm.SemesterViewModel>();

            ViewData["ActiveSemester"] = result;

            return PartialView("_AllSubjecsBySemester");
        }

        public async Task<JsonResult> GetAllProfessor()
        {
            var result = await _professorService.GetAllAsync();
            return Json(result.GenericConvertList<vm.ProfessorViewModel>(), JsonRequestBehavior.AllowGet);
        }

        private Object ToJSON(vm.SemesterViewModel semester)
        {
            return JsonConvert.SerializeObject(semester, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public RecordController(ISubjectService subjectService,ISemesterService semesterService, IRecordService recordService, IProfessorService professorfService)
        {
            this._subjectService = subjectService;
            this._semesterService = semesterService;
            this._recordService = recordService;
            this._professorService = professorfService;
        }

        private ISubjectService _subjectService { get; set; }
        private ISemesterService _semesterService { get; set; }
        private IRecordService _recordService { get; set; }
        public IProfessorService _professorService { get; set; }
    }
}