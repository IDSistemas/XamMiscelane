using System;
using System.Collections.Generic;
using System.Text;

namespace Miscelanea.Models
{
    public enum MenuItemType
    {
        Inicio,
        Cuenta,
        Categorias,
        AcercaDe
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
