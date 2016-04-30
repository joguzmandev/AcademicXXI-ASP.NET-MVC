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

namespace Academic.Web.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public async Task<ActionResult> Index()
        {

            var students = await _studentService.GetAllAsync();
            
            
            return View(students.MapToStudentViewModelToStudentList());
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