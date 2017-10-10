using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AcademicXXI.Web.Controllers
{
    public class LoginController : Controller
    {
        private const String _userName = "Demo";
        private const String _password = "Demo";
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }
        [HttpPost]
        public ActionResult Login(String userName,String password)
        {
            if(_userName.Equals(userName) && _password.Equals(password))
            {
                FormsAuthentication.SetAuthCookie(userName, true);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.error = "Datos incorrecto, vuelva a ingresar sus datos correctamente";
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}