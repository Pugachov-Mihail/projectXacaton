using Xamarin.Forms;
using MopileApps.Client;
using Newtonsoft.Json.Linq;
using System;
using MopileApps.Server;

namespace MopileApps
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            //


            ServerFile server = new ServerFile();
            ParserJson parser = new ParserJson();
            server.GetRequest("/api/news/");

            ViewNews viewNews = new ViewNews(){
                
            };
            
            this.BindingContext = viewNews;

            Console.WriteLine("_______" + server.response);

        }
    }
}
