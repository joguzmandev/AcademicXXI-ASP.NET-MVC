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
            if (_studentService.ValidateDocumentID(student.DocumentID))
            {
                return View(student).WithError("Número de Cedula ingresado ya existe");
            }
            if (_studentService.ValidateRegisterNumber(student.RegisterNumber))
            {
                return View(student).WithError("Matrícula ingresada ya existe");
            }

            var studentEntity = student.MapToStudent();
            studentEntity.Id = Guid.NewGuid();
            studentEntity.Status = Status.Active;
            studentEntity.Created = DateTime.Now;
            _studentService.Add(studentEntity);


            return RedirectToAction("Create").WithSuccess($"{student.FullName}, fue creado satisfactoriamente");
        }

        public ActionResult Edit(String Id)
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
            //TODO perform to update action
            return RedirectToAction("Maintenance");
        }

        public async Task<ActionResult> Maintenance()
        {
            var students = await _studentService.GetAllAsync();
            var studentViewModelList = students.MapToStudentViewModelToStudentList();

            List<SelectListItem> options = new List<SelectListItem>() {
                new SelectListItem()
                {
                    Text = "Nombre",
                    Value = "FirstName"

                },
                new SelectListItem()
                {
                    Text = "Apellido",
                    Value = "LastName"
                },
                new SelectListItem()
                {
                    Text = "Cedula",
                    Value = "DocumentID"
                },
                new SelectListItem()
                {
                    Text = "Matrícula",
                    Value = "RegisterNumber"
                }
            };
            ViewBag.listOfItem = options;
            return View(studentViewModelList);
        }

        public async Task<ActionResult> Filter(String search,String filterItem,String DisplayAll="None")
        {
            List<Student> listOfStudents = new List<Student>();

            if (DisplayAll.Equals("DisplayAll"))
            {
                listOfStudents = await _studentService.GetAllAsync();
                
            }else
            {
                switch (filterItem)
                {
                    case "FirstName":
                        listOfStudents = _studentService.FindAll(s => s.FirstName.Contains(search));
                        break;
                    case "LastName":
                        listOfStudents = _studentService.FindAll(s => s.LastName.Contains(search));
                        break;
                    case "DocumentID":
                        listOfStudents = _studentService.FindAll(s => s.DocumentID.Contains(search));
                        break;
                    case "RegisterNumber":
                        listOfStudents = _studentService.FindAll(s => s.RegisterNumber.Contains(search));
                        break;
                }
                ViewData["IsFilter"] = true;
            }

            
           
           
            return PartialView("_DisplayAllStudentList", listOfStudents.MapToStudentViewModelToStudentList());
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