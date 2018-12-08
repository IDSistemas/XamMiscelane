using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miscelanea.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Miscelanea.Helpers;
using Newtonsoft.Json;

namespace Miscelanea.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Usuario loginModel = new Usuario
            {
                sNombreUsuario = txtUsuario.Text.Trim(),
                sContrasena = txtContrasena.Text.Trim()
            };

            RequestREST<Usuario> requestObject = new RequestREST<Usuario>()
            {
                Dato = loginModel,
                EnumFiltro=3,
                sAutorizacion = "ShopCommerce Xamarin"
            };
            string sRequest = JsonConvert.SerializeObject(requestObject, Formatting.None);
            string sResponse = string.Empty;
            string sError = string.Empty;
            HttpHelper.GenericHttpRequest("POST", "http://machsolutions.azurewebsites.net/WCFUsuarioREST.svc/json/GetItemUsuario", sRequest, ref sResponse, ref sError);

            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sResponse);

            if (usuario != null)
            {
                Persona p = new Persona()
                {
                    nIdPersona = usuario.nIdPersona.GetValueOrDefault(0)
                };

                RequestREST<Persona> requestREST = new RequestREST<Persona>();
                requestREST.EnumFiltro = 1;
                requestREST.Dato = p;
                requestREST.sAutorizacion = "ShopCommerce Xamarin";

                sRequest = JsonConvert.SerializeObject(requestREST);
                sResponse = string.Empty;
                sError = string.Empty;
                HttpHelper.GenericHttpRequest("POST", "http://machsolutions.azurewebsites.net/WCFUsuarioREST.svc/json/GetItemPersona", sRequest, ref sResponse, ref sError);
                p = JsonConvert.DeserializeObject<Persona>(sResponse);
                if (p != null)
                {
                    DisplayAlert("Login", $"Usuario valido: {p.sCorreoElectronico}", "Aceptar");
                }
                else
                {
                    DisplayAlert("Login", "Persona Invalida", "Aceptar");
                }
            }
            else
            {
                DisplayAlert("Login", "Usuario Invalido", "Aceptar");
            }
            

        }
    }
}