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
	public partial class CuentaPage : ContentPage
	{
		public CuentaPage ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Codigo
            Navigation.PushModalAsync(new LoginPage(), true);
        }
    }
}