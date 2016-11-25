using Newtonsoft.Json;
using System;
using System.Net.Http;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Channel_app
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
             
            getjson();
        }
        public async void getjson()
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync("http://scrapper909.azurewebsites.net/");
                var result = await response.Content.ReadAsStringAsync();
                var rootobj = JsonConvert.DeserializeObject<RootObject>(result);
                mylist.ItemsSource = rootobj.channels;
            }

            catch (Exception e)
            {
                var dialog = new MessageDialog("Connection Error");
               await dialog.ShowAsync();

            }



        }

        private void mylist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value=(Channel)mylist.SelectedItem;
            string channellink = value.channellink;
            App.channellink= value.channellink; ;
            // var selected = (Channel)sender;

            
            Frame.Navigate(typeof(drama));
        }

        

         
    }
}
