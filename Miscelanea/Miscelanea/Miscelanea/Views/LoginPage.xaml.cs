using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Miscelanea.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            Models.UserModels.Dato _Dato = new Models.UserModels.Dato() { sNombreUsuario=User.Text.Trim(), sContraseña=Password.Text.Trim() };
            Models.UserModels.LoginRequest _request = new Models.UserModels.LoginRequest() { EnumFiltro=3, sAutorizacion="ShopCommerce Xamarin", Dato= _Dato };

            string _response = "";
            string _error = "";

            Helpers.HttpHelper.GenericHttpRequest("POST", "http://machsolutions.azurewebsites.net/WCFUsuarioREST.svc/json/GetItemUsuario", Newtonsoft.Json.JsonConvert.SerializeObject(_request), ref _response, ref _error);

            var _anonimo = Newtonsoft.Json.JsonConvert.DeserializeObject(_response);

            DisplayAlert("", "Login", "OK");
        }
    }
}