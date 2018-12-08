using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Miscelanea.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OtherPage : ContentPage
    {
        public OtherPage()
        {
            InitializeComponent();
            txt1.Text = Preferences.Get("Val1", "");
            txt2.Text = Preferences.Get("Val2", "");
        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("Val1", txt1.Text);
            Preferences.Set("Val2", txt2.Text);
            DisplayAlert("Guardar Preferencias", "Informacion guardada", "Cerrar");
        }
    }
}