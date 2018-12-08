using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Miscelanea.Models;
using Miscelanea.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using ZXing.Net.Mobile.Forms;

namespace Miscelanea.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaProductos : ContentPage
    {
        public ObservableCollection<Producto> Items { get; set; }

        public ListaProductos()
        {
            InitializeComponent();

            //Items = 
            RequestREST<Producto> requestObject = new RequestREST<Producto>();
            requestObject.EnumFiltro = 5;
            requestObject.sAutorizacion = "ShopCommerce Xamarin";
            string sRequest = JsonConvert.SerializeObject(requestObject, Formatting.None);
            string sResponse = string.Empty;
            string sError = string.Empty;
            if (!HttpHelper.GenericHttpRequest("POST", "http://machsolutions.azurewebsites.net/WCFMiscelaneaREST.svc/json/GetListProducto", sRequest, ref sResponse, ref sError))
            {
                DisplayAlert("Productos", $"Ha ocurrido un error: {sError}", "Aceptar");
            }
            else
            {
                Items = new ObservableCollection<Producto>(JsonConvert.DeserializeObject<List<Producto>>(sResponse));
                MyListView.ItemsSource = Items;
            }
            
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async Task BtnFiltro_ClickedAsync(object sender, EventArgs e)
        {
            ZXingScannerPage scannerPage = new ZXingScannerPage();
            scannerPage.OnScanResult += (result) =>
            {
                scannerPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                    txtFiltro.Text = result.Text;
                });
            };
            await Navigation.PushModalAsync(scannerPage);
        }
    }
}
