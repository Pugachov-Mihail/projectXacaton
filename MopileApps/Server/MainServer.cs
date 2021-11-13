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
            string url = "https://f972-185-34-240-5.ngrok.io/api/news/";

            try
            {


                HttpClient client = new HttpClient();
<<<<<<< HEAD
                //client.BaseAddress = new Uri(url);
                while (true)
                {
                    string response = await client.GetStringAsync(url);
                    var result = JToken.Parse(response);
                    string rateInfo = result[0].ToString();
                    //var rateInfo = JsonConvert.DeserializeObject<ViewNews>(result.ToString());
                    Console.WriteLine(rateInfo);
                    //this.id = rateInfo;
=======
                string response = await client.GetStringAsync(url);
                var result = JToken.Parse(response);
                string rateInfo = result.ToString();

                for (int i = 0; i < result.ToString().Length; i++)
                {
             
                    this.News = result[i]["news"].ToString();
                    this.Autor = result[i]["autor"].ToString();
                    this.Date = result[i]["date"].ToString();
                    this.Text = result[i]["text"].ToString();
                    Console.WriteLine("param --------" + result[i]);

                }

>>>>>>> a1c60c967999679a9ecdd9b06acf0049f04ee092

                    this.News = result[0]["news"].ToString();
                    this.News = result[1]["news"].ToString();
                    this.Autor = result[0]["autor"].ToString();
                    this.Date = result[0]["date"].ToString();
                    this.Text = result[0]["text"].ToString();
                }
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
