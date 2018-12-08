using System;
using System.Collections.Generic;
using System.Text;

namespace Miscelanea.Models
{
    public class Usuario
    {
        public int nIdUsuario { get; set; }
        public int? nIdPersona { get; set; }
        public int? nIdEstadoUsuario { get; set; }
        public string sNombreUsuario { get; set; }
        public string sContrasena { get; set; }
        public DateTime? dFechaUltimoIngreso { get; set; }
        public DateTime? dFechaUltimoCambio { get; set; }
        public bool? bEstado { get; set; }
    }
}
