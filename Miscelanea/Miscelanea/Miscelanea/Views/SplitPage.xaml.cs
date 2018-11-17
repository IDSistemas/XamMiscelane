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
	public partial class SplitPage : ContentPage
	{
		public SplitPage ()
		{
			InitializeComponent ();
		}

        private void btn1_Clicked(object sender, EventArgs e)
        {
            lblContenido.Text = "Texto 1";
        }

        private void btn2_Clicked(object sender, EventArgs e)
        {
            lblContenido.Text = "Texto 2";
        }

        private void btn3_Clicked(object sender, EventArgs e)
        {
            lblContenido.Text = "Texto 3";
        }
    }
}