using Newtonsoft.Json;
using System;
using System.Net.Http;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Channel_app
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Videopage : Page
    {
        public Videopage()
        {
            this.InitializeComponent();
            getvideolink();
           

            //WebView1.NavigateToString(html);

        }

        public async void getvideolink()
        {
            try
            {
                var url = "http://scrapper909.azurewebsites.net/getData?url=" + App.epilink + "&type=epilink";
                var client = new HttpClient();
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                var rootobj = JsonConvert.DeserializeObject<epiRootObject>(result);
                App.videolink = rootobj.videolink;
            }

            catch (Exception e)
            {


            }


            string html = @"<iframe width=""800"" height=""480"" src=" + App.videolink + " allowfullscreen></iframe>";
            this.WebView1.NavigateToString(html);
        }
    }
}
