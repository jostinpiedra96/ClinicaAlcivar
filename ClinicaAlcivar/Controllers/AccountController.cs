using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicaAlcivar.Models;

namespace ClinicaAlcivar.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult InicioSesion()
        {
            return View();
        }
        public ActionResult Verificar(Account model)
        {
            return View();
        }
    }
}