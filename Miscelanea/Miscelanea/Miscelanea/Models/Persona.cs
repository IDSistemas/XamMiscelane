using System;
using System.Collections.Generic;
using System.Text;

namespace Miscelanea.Models
{
    public class Persona
    {
        public int nIdPersona { get; set; }
        public string sNombre { get; set; }
        public string sApellidoPaterno { get; set; }
        public string sApellidoMaterno { get; set; }
        public char[] sTelefono { get; set; }
        public string sCorreoElectronico { get; set; }
        public string sRFC { get; set; }
        public DateTime? dFechaNacimiento { get; set; }
        public bool? bEstado { get; set; }
    }
}
