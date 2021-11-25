using MobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace MobileApp.Server
{
    class Serv
    {
        HttpClient client = new HttpClient();
        string api = "api/news/";
        string url = "https://9f3f-185-34-240-5.ngrok.io/";

        public Serv()
        {

        }

        public async void GetItemsAsync()
        {
            HttpResponseMessage response = await client.GetAsync(url + api);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Item a = JsonConvert.DeserializeObject<Item>(content);
            }
        } 

    }
}
