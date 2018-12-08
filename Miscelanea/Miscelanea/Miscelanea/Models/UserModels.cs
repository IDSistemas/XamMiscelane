using System;
using System.Collections.Generic;
using System.Text;

namespace Miscelanea.Models
{
    public class UserModels
    {
        public class LoginRequest
        {
            public int EnumFiltro { get; set; }
            public string sAutorizacion { get; set; }
            public Dato Dato { get; set; }
            
        }

        public class Dato
        {
            public string sNombreUsuario { get; set; }
            public string sContrasena { get; set; }
        }

        public class LoginResponse
        {
            public Boolean bEstado { get; set; }
            public string dFechaUltimoCambio { get; set; }
            public string dFechaUltimoIngreso { get; set; }
            public int? nIdEstadoUsuario { get; set; }
            public int? nIdPersona { get; set; }
            public int? nIdUsuario { get; set; }
            public string sContraseña { get; set; }
            public string sNombreUsuario { get; set; }
        }
    }
}
