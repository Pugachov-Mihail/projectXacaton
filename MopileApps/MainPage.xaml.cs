using Xamarin.Forms;
using MopileApps.Client;
using Newtonsoft.Json.Linq;
using System;


namespace MopileApps
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            //

            
            Server server = new Server();
            server.GetRequest("/api/news/");
            JToken a = server.ServerParse(server.response);
            
            ViewNews viewNews = new ViewNews();
            for(int i=0; i<a.ToString().Length; i++)
            {
                viewNews.Title = a[0]["title"].ToString();
            }

            this.BindingContext = viewNews;

            Console.WriteLine("_______" + server.response);
            Console.WriteLine("_______" + server.ServerParse(server.response));
        }
    }
}
