using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Miscelanea.Models
{
    public class Producto
    {
        public int nIdProducto { get; set; }
        public string sNombreProducto { get; set; }
        public string sDescripcion { get; set; }
        public string sMarca { get; set; }
        public string sUnidadMedida { get; set; }
        public decimal nPrecio { get; set; }
        public string sCategoria { get; set; }
        public byte[] Imagen { get; set; }
        public bool bEstado { get; set; }
        public ImageSource ImagenSource
        {
            get
            {
                if (Imagen != null)
                {
                    return ImageSource.FromStream(() =>
                    {
                        return new MemoryStream(Imagen);
                    });
                }
                else
                {
                    return null;
                }

            }
        }
    }
}
