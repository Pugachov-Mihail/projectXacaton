using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;

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

        private List<string> newTitle;
        public List<string> NewTitle
        {
            get { return newTitle; }
            private set
            {
                newTitle = value;
                OnPropertyChanged("NewTitle");
            }
        }

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
            string api = "/api/news/";
            string url = "https://b697-185-34-240-5.ngrok.io" + api;

            try
            {


                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(url);
                var result = JToken.Parse(response);
                string rateInfo = result.ToString();

                for (int i = 0; i < result.ToString().Length; i++)
                {
                    int.TryParse(Console.ReadLine(), out int n);
                    this.Id = n;
                    this.Title = result[i]["title"].ToString();
                    this.News = result[i]["news"].ToString();
                    this.Autor = result[i]["autor"].ToString();
                    this.Date = result[i]["date"].ToString();
                    this.Text = result[i]["text"].ToString();
                    newTitle.Add(Title);
                    Console.WriteLine("param --------" + result[i]);

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
