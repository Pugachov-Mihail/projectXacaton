using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;

namespace MopileApps.Client
{
    ///const string Url = "http://127.0.0.1:8000/api/news/";
    public class MainServer: INotifyPropertyChanged
    {
        private int id;
        private string title;
        private string news;
        private string autor;
        private string date;
        private string text;

        public int Id
        {
            get { return id; }
            private set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Title
        {
            get { return title; }
            private set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public string News
        {
            get { return news; }
            private set
            {
                news = value;
                OnPropertyChanged("News");
            }
        }
        public string Autor
        {
            get { return autor; }
            private set
            {
                autor = value;
                OnPropertyChanged("Autor");
            }
        }
        public string Date
        {
            get { return date; }
            private set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
        public string Text
        {
            get { return text; }
            private set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }
        public ICommand LoadDataCommand { protected set; get; }

        public MainServer()
        {
            this.LoadDataCommand = new Command(LoadData);
        }

        public async void LoadData()
        {
            string url = "https://f2f1-185-34-240-62.ngrok.io/api/news/";

            try
            {
                //var handler = new HttpClientHandler();
                HttpClient client = new HttpClient();
                //client.BaseAddress = new Uri(url);
                string response = await client.GetStringAsync(url);
                var result = JToken.Parse(response);
                string rateInfo = result[0].ToString();
                //var rateInfo = JsonConvert.DeserializeObject<ViewNews>(result.ToString());
                Console.WriteLine(rateInfo);
                //this.id = rateInfo;

                Console.WriteLine(this.title);
                this.News = result[0]["news"].ToString();
                this.Autor = result[0]["autor"].ToString();
                this.Date = result[0]["date"].ToString();
                this.Text = result[0]["text"].ToString();

            }
            catch (Exception ex)
            { Console.WriteLine(ex); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
