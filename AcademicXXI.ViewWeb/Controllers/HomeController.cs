using AcademicXXI.Services.StudentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AcademicXXI.ViewModel.ViewModel;

namespace AcademicXXI.ViewWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var result = _studentService.Find(st => st.Id == 2);
            var maptoView = Mapper.Map<StudentViewModel>(result);

            return View(maptoView);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _studentService.Dispose();

        }

        public HomeController(IStudentService studentService)
        {
            this._studentService = studentService;
        }

        private readonly IStudentService _studentService;



    }
}