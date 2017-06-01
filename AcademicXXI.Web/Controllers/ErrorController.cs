using AcademicXXI.ViewModel.ErrorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AcademicXXI.Web.Controllers
{
    [Authorize]
    public class ErrorController : Controller
    {
        
        /// <summary>
        /// HTTP ERROR 500 (INTERNAL SERVER ERROR)
        /// </summary>
        /// <returns></returns>
        public ActionResult Http500(){
            var errorViewM = new ErrorViewModel()
            {
                HttpStatusCode = HttpStatusCode.InternalServerError,
                Title = "Ooop!, ha ocurrido un error en nuestro sistema"
            };
            return View("Index",errorViewM);
        }
    }
}