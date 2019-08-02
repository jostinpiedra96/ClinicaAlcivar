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
        string connectionString = @"data source=LAECP-ELPT20017\SQLEXPRESS; database=ClinicaKennedy; integrated security = SSPI;";
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
            con.ConnectionString = connectionString;
        }
        [HttpPost]
        public ActionResult Verificar(Account model)
        {
            ViewBag.Nombre = model.Nombre;
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
            if (ModelState.IsValid)
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    string sql = $"Insert into usuarios (Nombre,Contraseña,Cedula,TipoUsuario) " +
                        $"values ('{model.Nombre}','{model.Contraseña}','{model.Cedula}', '{model.TipoUsuario}')";

                    using (SqlCommand command = new SqlCommand(sql,sqlcon))
                    {
                        command.CommandType = System.Data.CommandType.Text;
                        sqlcon.Open();
                        command.ExecuteNonQuery();
                        sqlcon.Close();
                    }
                    return View("LoginSuccessfully");
                }
            }
            else
            {
                return View();
            }
        }
    }
}