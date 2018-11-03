using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Miscelanea.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Acerca de";
            TextoBoton = "Click Aqui!";
            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
        public string TextoBoton { get; set; }

    }
}