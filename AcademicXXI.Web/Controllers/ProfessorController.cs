using AcademicXXI.Services.ProfessorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AcademicXXI.ViewModel.MapExtensionMethod;
using vm = AcademicXXI.ViewModel.ViewModel;
using domain = AcademicXXI.Domain;

namespace AcademicXXI.Web.Controllers
{
    public class ProfessorController : Controller
    {
        // GET: Professor
        public ActionResult Index()
        {
            return Content("SITE IN MAINTENANCE");
        }
    }
}