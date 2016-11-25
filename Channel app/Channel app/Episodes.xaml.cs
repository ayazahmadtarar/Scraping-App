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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Channel_app
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Episodes : Page
    {
        public Episodes()
        {
            this.InitializeComponent();
            getspisodeslist();
        }

        public async void getspisodeslist()
        {
            try
            {
                var url= "http://scrapper909.azurewebsites.net/getData?url="+App.dramalink+"&type=epilist";
                var client = new HttpClient();
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                var rootobj = JsonConvert.DeserializeObject<episodesRootObject>(result);
                epilist.ItemsSource = rootobj.epilist;
            }

            catch (Exception e)
            {


            }



        }

        private void epilist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = (Epilist)epilist.SelectedItem;

            App.epilink = value.episodeLink; ;
            myframe.Navigate(typeof(Videopage));
        }
    }
}
