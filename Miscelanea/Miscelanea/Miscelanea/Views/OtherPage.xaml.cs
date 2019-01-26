using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Fingerprint;

namespace Miscelanea.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OtherPage : ContentPage
    {
        public OtherPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception err)
            {

                throw;
            }
            
            txt1.Text = Preferences.Get("Val1", "");
            txt2.Text = Preferences.Get("Val2", "");
        }

        private async Task Btn1_Clicked(object sender, EventArgs e)
        {
            //var currentConectivity = Connectivity.NetworkAccess;
            //if(currentConectivity == NetworkAccess.Internet)
            //{
            //    await DisplayAlert("Guardar Preferencias", "Si tienes internet", "Cerrar");
            //}
            //var profiles = Connectivity.ConnectionProfiles;
            //if (profiles.Contains(ConnectionProfile.WiFi))
            //{
            //    await DisplayAlert("Guardar Preferencias", "Si tienes wifi", "Cerrar");
            //}
            //var location = await Geolocation.GetLastKnownLocationAsync();
            //if(location != null)
            //{
            //    await DisplayAlert("", $"Lat:{location.Latitude}, Long: {location.Longitude}, Alt: {location.Altitude}", "Cerrar");
            //}
            //Preferences.Set("Val1", txt1.Text);
            //Preferences.Set("Val2", txt2.Text);
            //DisplayAlert("Guardar Preferencias", "Informacion guardada", "Cerrar");
            //await Share.RequestAsync(new ShareTextRequest() {  });
            try
            {
                var result = await CrossFingerprint.Current.AuthenticateAsync("Pon tu dedo");
                if (result.Authenticated)
                {
                    await DisplayAlert("Validar Dedo", "Si es tu dedo", "Aceptar");
                }
                else
                {
                    await DisplayAlert("Validar Dedo", result.ErrorMessage, "Aceptar");
                }
            }catch(Exception err)
            {
                await DisplayAlert("Error", err.Message, "Aceptar");
            }
        }
    }
}