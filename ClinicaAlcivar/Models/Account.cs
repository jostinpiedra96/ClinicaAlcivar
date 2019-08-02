using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaAlcivar.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Cedula { get; set; }
        public string TipoUsuario { get; set; }
    }
}