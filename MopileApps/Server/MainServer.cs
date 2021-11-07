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
            string url = "https://10.0.2.2:8000/api/news/";

            try
            {
                HttpClient client = new HttpClient();
                // client.BaseAddress = new Uri(url);
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(content);

                var str = o.SelectToken(@"$.query.results.rate");
                var rateInfo = JsonConvert.DeserializeObject<ViewNews>(str.ToString());

                this.id = rateInfo.Id;
                this.title = rateInfo.Title;
                this.news = rateInfo.News;
                this.autor = rateInfo.Autor;
                this.date = rateInfo.Date;
                this.text = rateInfo.Text;

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
