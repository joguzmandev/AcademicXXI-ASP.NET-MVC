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
            ViewBag.ListOfStudyPlans = result.MapToStudyPlanViewModelFromStudyPlanList();
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
            if (!String.IsNullOrEmpty(student.StudyPlanIDStr))
            {
                try
                {
                    Guid studyPlanTemp = Guid.Parse(student.StudyPlanIDStr);
                    student.StudyPlanId = studyPlanTemp;
                }
                catch (ArgumentException)
                {

                    return View(student).WithError("Seleccione un plan de estudio correcto");
                }
                catch(FormatException)
                {
                    return View(student).WithError("Seleccione un plan de estudio correcto");
                }

            }

            var studentEntity = student.MapToStudent();
            studentEntity.Id = Guid.NewGuid();
            studentEntity.Status = Status.Active;
            studentEntity.Created = DateTime.Now;
            _studentService.Add(studentEntity);


            return RedirectToAction("Create").WithSuccess($"{student.FullName}, fue creado satisfactoriamente");
        }

        public async Task<ActionResult> Edit(String Id)
        {
            Guid idStuViewM;
            try
            {
                idStuViewM = Guid.Parse(Id);
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

            StudentViewModel studentViewM = entity.MapToStudentViewModel();
            if (studentViewM.StudyPlanId.HasValue)
            {
                studentViewM.StudyPlanIDStr = studentViewM.StudyPlanId.Value.ToString();
            }
            var result = await this._studyPlanService.GetAllAsync();
            ViewBag.ListOfStudyPlans = result.MapToStudyPlanViewModelFromStudyPlanList();

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

            if (!String.IsNullOrEmpty(student.StudyPlanIDStr))
            {
                try
                {
                    Guid studyPlanTemp = Guid.Parse(student.StudyPlanIDStr);
                    student.StudyPlanId = studyPlanTemp;
                }
                catch (ArgumentException)
                {

                    return View(student).WithError("Seleccione un plan de estudio correcto");
                }
                catch (FormatException)
                {
                    return View(student).WithError("Seleccione un plan de estudio correcto");
                }

            }

            _studentService.Update(student.MapToStudent());



            return RedirectToAction("Maintenance");
        }

        public async Task<ActionResult> Maintenance()
        {
            var students = await _studentService.GetAllAsync();
            var studentViewModelList = students.MapToStudentViewModelToStudentList();

            return View(studentViewModelList);
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