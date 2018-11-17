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
	public partial class Pagina1 : ContentPage
	{
		public Pagina1 ()
		{
			InitializeComponent ();
		}

        private void btnUno_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Pagina2();
            //Navigation.PushAsync(new Pagina2(), true);
        }

        private void btnDos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Pagina2());
        }
    }
}