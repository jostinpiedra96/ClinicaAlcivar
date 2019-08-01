using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicaAlcivar.Models;
using System.Data.SqlClient;

namespace ClinicaAlcivar.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult InicioSesion()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }
        void CadenaConexion()
        {
            con.ConnectionString = @"data source=LAECP-ELPT20017\SQLEXPRESS; database=ClinicaKennedy; integrated security = SSPI;";
        }
        [HttpPost]
        public ActionResult Verificar(Account model)
        {
            CadenaConexion();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from usuarios where nombre = '"+model.Nombre+"' and contraseña = '"+model.Contraseña+"'"; //query
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("LoginSuccessfully");
            }
            else
            {
                con.Close();
                return View("LoginError");
            }
        }
        [HttpPost]
        public ActionResult Registro(Account model)
        {
            CadenaConexion();
            con.Open();
            com.Connection = con;
            com.CommandText = @"insert into usuarios (Nombre,Contraseña,Cedula) values (@nombre,@contraseña,@cedula)";
            com.Parameters.AddWithValue("@nombre", model.Nombre);
            com.Parameters.AddWithValue("@contraseña", model.Contraseña);
            com.Parameters.AddWithValue("@cedula", model.Cedula);
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("LoginSuccessfully");
            }
            else
            {
                con.Close();
                return View("LoginError");
            }
            
        }
    }
}