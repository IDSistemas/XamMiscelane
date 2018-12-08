using System;
using System.Collections.Generic;
using System.Text;

namespace Miscelanea.Models
{
    public class RequestREST<T>
    {
        public T Dato { get; set; }
        public string sAutorizacion { get; set; }
        public int EnumFiltro { get; set; }
    }
}
