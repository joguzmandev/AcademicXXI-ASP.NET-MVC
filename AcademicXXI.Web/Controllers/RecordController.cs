using AcademicXXI.Services.ProfessorService;
using AcademicXXI.Services.RecordService;
using AcademicXXI.Services.SemesterService;
using AcademicXXI.Services.StudentService;
using AcademicXXI.Services.SubjectService;
using AcademicXXI.ViewModel.MapExtensionMethod;
using AcademicXXI.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using domian = AcademicXXI.Domain;
using vm = AcademicXXI.ViewModel.ViewModel;

namespace AcademicXXI.Web.Controllers
{
    [Authorize]
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
        public JsonResult CreateRecord(String SAcademicYear, String selectAddSubject)
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

            var record = new domian.Record()
            {
                SemesterFK = SAcademicYear,
                SubjectFK = selectAddSubject,
                Created = DateTime.Now,
                Status = Helpers.Status.Active
            };
            try
            {
                _recordService.Add(record);
            }
            catch (Exception e)
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
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //TODO Pending to validate
        public JsonResult AddSessionRecord(
            String subject, String semester, String NumericSession,
            String SessionDescription, String LimitSession, String Professor)
        {
            //Get Record
            var record = _recordService.Find(r => r.SubjectFK.Equals(subject) && r.SemesterFK.Equals(semester));
            if (record == null)
            {
                Message msg = new Message()
                {
                    Class = "alert alert-danger",
                    Messages = "Error",
                    Code = -1
                };
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

            var key1 = record.SemesterFK.Replace("-", string.Empty);
            var key2 = record.SubjectFK.Replace("-", string.Empty);
            var key3 = NumericSession.ToString();

            var recordDetail = new domian.RecordDetails()
            {
                RecordDetailId = $"{key1 + key2 + key3}",
                SubjectFK = record.SubjectFK,
                SemesterFK = record.SemesterFK,
                NumericSession = Int32.Parse(NumericSession),
                SessionDescription = SessionDescription,
                LimitSession = Int32.Parse(LimitSession),
                ProfessorFK = String.IsNullOrEmpty(Professor) ? null : Professor,
                Status = Helpers.Status.Active,
                Created = DateTime.Now,
            };
            record.RecordDetails.Add(recordDetail);
            try
            {
                _recordService.Update(record);
            }
            catch (Exception e)
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

            return Json(new Message()
            {
                Class = "alert alert-success",
                Messages = "Sección registrada satisfactoriamente"
            }
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //TODO Pending to validate
        public PartialViewResult GetAllSessionBySubject(String semester, String subject)
        {
            var result = _recordService.GetAllSessionBySubject(semester, subject);
            ViewData["AllSessionBySubject"] = result.GenericConvertList<vm.RecordDetailsViewModel>();
            return PartialView("_DisplayAllSessionBySubject");
        }

        public async Task<ActionResult> GetAllSubject()
        {
            var result = await _subjectService.GetAllAsync();

            return Json(result.GenericConvertList<vm.SubjectViewModel>(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DisplayStudentRecord(String semester, String subject, String session)
        {
            var result = _recordService.RecordStudent(session);
            return View(result.GenericConvertList<vm.SpRecordStudentViewModel>());
        }

        [HttpPost]
        public ActionResult DisplayStudentRecord(List<vm.SpRecordStudentViewModel> studentsRecord)
        {
            bool isOk = _recordService.UpdateLineRecordStudentDetail(studentsRecord.GenericConvertList<domian.SpRecordStudent>());
            if (isOk)
            {
                return Json("OK", JsonRequestBehavior.AllowGet);
            }
            return Json("Fail", JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchingSubjectSessions(String subjectCode, String SemesterCode)
        {
            Message msg = null;
            if (String.IsNullOrEmpty(subjectCode) || string.IsNullOrEmpty(SemesterCode))
            {
                msg = new Message()
                {
                    Class = "alert alert-danger",
                    Messages = "Error - Semestre - Asignatura",
                    Code = -1
                };
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            var result = _recordService.GetRecordWithSubjectAndSessions(subjectCode, SemesterCode);

            if (result == null)
            {
                msg = new Message()
                {
                    Class = "alert alert-danger",
                    Messages = "Error - Semestre - Asignatura",
                    Code = -1
                };
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

            return Json(result.GenericConvert<vm.RecordViewModel>(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetSemesterSubjects(String semesterCode, String TypePage)
        {
            var result = _semesterService.GetSemesterSubjects(semesterCode).GenericConvert<vm.SemesterViewModel>();

            if (TypePage == null && result != null)
            {
                ViewData["ActiveSemester"] = result;
                return PartialView("_AllSubjecsBySemester");
            }
            else if (TypePage.Equals("Json") && result != null)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return RedirectToAction("Index");
        }

        public async Task<JsonResult> GetAllProfessor()
        {
            var result = await _professorService.GetAllAsync();
            return Json(result.GenericConvertList<vm.ProfessorViewModel>(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult IncludeStudentToSession(String RecordDetailId, String StudentRegisterNumber)
        {
            var msg = new Message();

            //1: Validate RecordDetailId and StudentRegisterNumber are not empty
            if (String.IsNullOrEmpty(RecordDetailId))
            {
                msg.Class = "alert alert-danger";
                msg.Code = -1;
                msg.Messages = "Error : Vuelta a recargar la página";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(StudentRegisterNumber))
            {
                msg.Class = "alert alert-danger";
                msg.Code = -1;
                msg.Messages = "Error - Campo Matrícula es requerido";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

            //2: Find Student with RegisterNumber
            var studentFound = _studentService.Find(s => s.RegisterNumber.Equals(StudentRegisterNumber));

            //3: Validate if StudentRegisterNumber exit
            if (studentFound == null)
            {
                msg.Class = "alert alert-danger";
                msg.Code = -1;
                msg.Messages = "Error - Matrícula no existe / Incompleta";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            //4: Find RecordDetails with RecordDetailId
            var record_details = _recordService.GetRecordWithRecordDetailsByRDId(RecordDetailId);

            //5: Validate if record_details exit
            if (record_details == null)
            {
                msg.Class = "alert alert-danger";
                msg.Code = -1;
                msg.Messages = "Error";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

            bool exit = _recordService.ValidateIfGivenSubject(RecordDetailId, StudentRegisterNumber);
            if (exit)
            {
                msg.Class = "alert alert-danger";
                msg.Code = -1;
                msg.Messages = "Error : Posibles error [Estudiante matriculado en otra sección de esta misma asignatura] [Asignatura cursada y aprobada]";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

            //6: Student add a new LineRecordStudentDetails
            var ID = $"{studentFound.RegisterNumber}{record_details.SubjectFK}{record_details.NumericSession}";
            studentFound.LineRecordStudentDetails.Add(new domian.LineRecordStudentDetails()
            {
                LineRecordStudentID = ID.Replace("-", string.Empty),
                RecordDetailsFK = record_details.RecordDetailId,
                Created = DateTime.Now,
                Status = Helpers.Status.Active
            });
            try
            {
                //7: Update Student and save
                _studentService.Update(studentFound);
            }
            catch (Exception e)
            {
                msg.Class = "alert alert-danger";
                msg.Code = -1;
                msg.Messages = $"Error {e.Message}";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            msg.Class = "alert alert-success";
            msg.Code = 1;
            msg.Messages = $"Agregado satisfactoriamente.";
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExcludeStudentToSession(String RecordDetailId, String SubjectFK, String SemesterFK, String NumericSession)
        {
            return View();
        }

        private Object ToJSON(vm.SemesterViewModel semester)
        {
            return JsonConvert.SerializeObject(semester, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public async Task<ActionResult> MaintenanceSessionToRecord()
        {
            var result = await _semesterService.GetAllAsync();

            SelectList list = new SelectList(result.GenericConvertList<vm.SemesterViewModel>(), "SemesterCode", "DisplaySemesterDescription");
            ViewBag.GetAllSemester = list;
            return View();
        }

        public async Task<ActionResult> IntroduceManualRecord()
        {
            var result = await _semesterService.GetAllAsync();

            SelectList list = new SelectList(result.GenericConvertList<vm.SemesterViewModel>(), "SemesterCode", "DisplaySemesterDescription");
            ViewBag.GetAllSemester = list;
            return View();
        }

        public RecordController(ISubjectService subjectService, ISemesterService semesterService, IRecordService recordService, IProfessorService professorfService, IStudentService studentService)
        {
            this._subjectService = subjectService;
            this._semesterService = semesterService;
            this._recordService = recordService;
            this._professorService = professorfService;
            this._studentService = studentService;
        }

        private ISubjectService _subjectService { get; set; }
        private ISemesterService _semesterService { get; set; }
        private IRecordService _recordService { get; set; }
        private IProfessorService _professorService { get; set; }
        private IStudentService _studentService { get; set; }
    }
}