using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;

namespace Miscelanea.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();
            //Map map = new Map(MapSpan.FromCenterAndRadius(new Position(37, -122), Distance.FromMiles(.3)))
            //{
            //    IsShowingUser = true,
            //    HeightRequest = 100,
            //    WidthRequest = 960,
            //    VerticalOptions = LayoutOptions.FillAndExpand
            //};
            //StackLayout stack = new StackLayout { Spacing = 0 };
            //stack.Children.Add(map);
            //Content = stack;
            
        }

        private async void BtnAddPosition_Clicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                MyMap.Pins.Add(new Pin() { Position = new Position(location.Latitude, location.Longitude), Label = "Aqui estoy" });
            }
            catch(Exception err)
            {
                await DisplayAlert("Error", err.Message, "Aceptar");
            }
        }
    }
}