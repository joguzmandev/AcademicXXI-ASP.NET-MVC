using AcademicXXI.Services.StudentService;
using AcademicXXI.ViewModel.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AcademicXXI.ViewModel.MapExtensionMethod;
using AcademicXXI.Helpers;
using Academic.Web.Helpers.Alerts;
using AcademicXXI.Domain;
using AcademicXXI.Services.StudyPlanService;
using vm = AcademicXXI.ViewModel.ViewModel;
using domain = AcademicXXI.Domain;
using Newtonsoft.Json;
using System.Net;

namespace Academic.Web.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return RedirectToAction("Maintenance");
        }

        public async Task<ActionResult> Create()
        {
            var result = await this._studyPlanService.GetAllAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return View(student).WithError("Hubo un error en el modelo");
            }
            if (_studentService.ValidateDocumentID(student.DocumentID))
            {
                return View(student).WithError("Número de Cedula ingresado ya existe");
            }
            if (_studentService.ValidateRegisterNumber(student.RegisterNumber))
            {
                return View(student).WithError("Matrícula ingresada ya existe");
            }

            var studentEntity = student.GenericConvert<domain.Student>();
            studentEntity.Status = Status.Active;
            studentEntity.Created = DateTime.Now;
            _studentService.Add(studentEntity);

            return RedirectToAction("Create").WithSuccess($"{student.FullName}, fue creado satisfactoriamente");
        }

        public async Task<ActionResult> Edit(String Id)
        {
            Int32 idStuViewM;
            try
            {
                idStuViewM = Convert.ToInt32(Id);
            }
            catch (Exception)
            {
                return RedirectToAction("Maintenance");
            }

            var entity = _studentService.Find(s => s.Id == idStuViewM);

            if (entity == null)
            {
                return RedirectToAction("Maintenance");
            }

            StudentViewModel studentViewM = entity.GenericConvert<vm.StudentViewModel>();
        
            var result = await this._studyPlanService.GetAllAsync();
            ViewBag.ListOfStudyPlans = result.GenericConvertList<vm.StudyPlanViewModel>();

            return View(studentViewM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return View(student).WithError("Hubo un error en el modelo");
            }
            _studentService.Update(student.GenericConvert<domain.Student>());

            return RedirectToAction("Maintenance");
        }

        public async Task<ActionResult> Maintenance()
        {
            var students = await _studentService.GetAllAsync();
            var studentViewModelList = students.GenericConvertList<vm.StudentViewModel>();

            return View(studentViewModelList);
        }

        public async Task<ActionResult> AddPlanToStudent()
        {
            var result  = await this._studyPlanService.GetAllAsync();
            ViewBag.StudyPlanes = result.GenericConvertList<vm.StudyPlanViewModel>();
            return View();
        }

        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddPlanToStudent(String registernumber,Int32? studentid,String documentid,
            String plancode, Int32? planid)
        {
            if (String.IsNullOrEmpty(registernumber) || String.IsNullOrEmpty(documentid) || String.IsNullOrEmpty(plancode))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error, vuelva a intentarlo de nuevo ");
            }
            if(!studentid.HasValue && studentid < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error, vuelva a intentarlo de nuevo ");
            }
            if (!planid.HasValue && planid < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error, vuelva a intentarlo de nuevo ");
            }

            //Validate StudyPlan Exit
            StudyPlan sp = this._studyPlanService.Find(sp1=> sp1.Code.Equals(plancode) && sp1.Id == planid);

            Student st = this._studentService.Find(s => s.RegisterNumber.Equals(registernumber) && s.Id == studentid && s.DocumentID.Equals(documentid));

            if(st != null && sp != null)
            {
                st.StudentPlans.Add(new StudentPlan()
                {
                    Created = DateTime.Now,
                    StudyPlan = sp,
                    StudyPlanID = sp.Id
                });

                _studentService.Update(st);
                var data = new { Message = "Plan Asociado satisfactoriamente", status = "OK" };

                return Json(JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
                ));
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Error, vuelva a intentarlo de nuevo ");
            }
        }

        public ActionResult FindStudent(String RegisterNumber)
        {

            if (String.IsNullOrEmpty(RegisterNumber))
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "registro no encontrado");
            }

            var studentvm = _studentService.FindStudentWithStudyPlan(x => x.RegisterNumber.Equals(RegisterNumber));
            if(studentvm != null)
            {
                return Json(JsonConvert.SerializeObject(studentvm.GenericConvert<vm.StudentViewModel>(),Formatting.Indented,new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
                ));
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound,"registro no encontrado");
            }
            
        }
        public StudentController(IStudentService service, IStudyPlanService studyPlanService)
        {
            this._studentService = service;
            this._studyPlanService = studyPlanService;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._studentService.Dispose();
            this._studyPlanService.Dispose();
        }
        private readonly IStudyPlanService _studyPlanService;
        private readonly IStudentService _studentService;


    }
}