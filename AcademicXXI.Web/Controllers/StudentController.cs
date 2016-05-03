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

namespace Academic.Web.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return RedirectToAction("Maintenance");
        }

        public ActionResult Create()
        {
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
            try
            {
                if (_studentService.ValidateDocumentID(student.DocumentID))
                {
                    return View(student).WithError("Número de Cedula ingresado ya existe");
                }
                if (_studentService.ValidateRegisterNumber(student.RegisterNumber))
                {
                    return View(student).WithError("Matrícula ingresada ya existe");
                }

                var studentEntity = student.MapToStudent();
                studentEntity.Status = Status.Active;
                studentEntity.Created = DateTime.Now;
                _studentService.Add(studentEntity);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Create").WithError($"hubo un error al procesar su petición, vuelva a intentarlo nuevamente");
            }
            return RedirectToAction("Create").WithSuccess($"{student.FullName}, fue creado satisfactoriamente");
        }

        public async Task<ActionResult> Maintenance()
        {
            try
            {
                var students = await _studentService.GetAllAsync();
                var studentViewModelList = students.MapToStudentViewModelToStudentList();
                return View(studentViewModelList);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult Filter(String search)
        {
            //TODO crear un metodo Find que retorne una lista de estudiantes
            //Que pueda buscar por Matricula,cedula,nombre,apellido,etc.
            var studentEntity = _studentService.Find(x => x.FirstName.Contains(search));
            List<Student> listOfStudent = new List<Student>();
            listOfStudent.Add(studentEntity);
            return PartialView("_DisplayAllStudentList",listOfStudent.MapToStudentViewModelToStudentList() );
        }


        public StudentController(IStudentService service)
        {
            this._studentService = service;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._studentService.Dispose();
        }
        private readonly IStudentService _studentService;


    }
}