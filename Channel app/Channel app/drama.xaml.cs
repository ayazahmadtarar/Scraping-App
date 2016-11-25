using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

 
namespace Channel_app
{
     
    public sealed partial class drama : Page
    {
        public drama()
        {
            this.InitializeComponent();
            getdramalist();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string channellink; channellink = e.Parameter as string;

        }
        public async void getdramalist()
        {
            try
            {
                //"http://scrapper909.azurewebsites.net/getData?url=http://dramaonline.com/aplus-entertainment-latest-dramas-episodes-online//&type=%22dramalist%22";


                var client = new HttpClient();
                //var url = "http://scrapper909.azurewebsites.net/getData?url="+ channellink + "&type=dramalist";
                var url = "http://scrapper909.azurewebsites.net/getData?url=" + App.channellink + "&type=dramalist";
               
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                var rootobj = JsonConvert.DeserializeObject<DramaRootObject>(result);
                dramalist.ItemsSource = rootobj.dramas;
            }

            catch (Exception e)
            {


            }



        }

        private void dramalist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = (Drama)dramalist.SelectedItem;
            
            App.dramalink = value.dramaLink; ;
            // var selected = (Channel)sender;


            myframe.Navigate(typeof(Episodes));
        }
    }
}
