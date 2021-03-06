using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MobileApp.Services
{
    public class MockDataStore 
    {
        readonly List<Item> items;

        public HttpClient client = new HttpClient();
        public string api = "api/news/";
        public string url = "https://0a0b-77-236-231-130.ngrok.io/";
        JsonSerializerOptions options = new JsonSerializerOptions();

        public MockDataStore()
        {
            items = new List<Item>();
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            //var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            //items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            //var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            //items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items[0]);
        }

        public async Task<(bool, User)> GetUserAsync(string login, string password)
        {
            User user = new User();
            HttpResponseMessage response = await client.GetAsync(url + api + "auth/token/login");
            if (!response.IsSuccessStatusCode)
                return await Task.FromResult((true, user));

            string content = await response.Content.ReadAsStringAsync();
            Item a = JsonConvert.DeserializeObject<Item>(content);
            return await Task.FromResult((true, user));
        }

        public async Task<IEnumerable<Item>> GetPostsAsync(bool forceRefresh = false)
        {
            string result = await client.GetStringAsync(url + api);
            //string result= "[{\"Title\":\"test\",\"News\":null,\"Text\":\"test\",\"Date\":\"2021-11-27\",\"Publication\":false}, {\"Title\":\"SecondTitle\",\"News\":null,\"Text\":\"test\",\"Date\":\"2021-11-27\",\"Publication\":true}]";
            Debug.WriteLine($"RESULT: {result}");
            var itemParse = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ItemParse>>(result, options);
            List<Item> newitems = items;
            List<string> itemsT = new List<string>();
            foreach (var item in items)
            {
                itemsT.Add(item.Title);
            }
                foreach (var item in itemParse)
            {
                if (!itemsT.Contains(item.title))
                {
                    newitems.Add(new Item
                    {
                        Title = item.title,
                        Text = item.text,
                        Date = item.date,
                        News = item.news,
                        Publication = item.publication,
                        UserFirstName = item.user.first_name,
                        UserSecondName = item.user.last_name
                    });
                }
            }
            return newitems;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            Debug.WriteLine("No Начал парсить");
            /*HttpResponseMessage response = await client.GetAsync(url + api );
            Debug.WriteLine("Коннекшн");
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Начал парсить");
                string content = await response.Content.ReadAsStringAsync();
                Item a = JsonConvert.DeserializeObject<Item>(content);
                items.Add(a);
                Debug.WriteLine("Закончить парсить");
            }
            else
            {
                Debug.WriteLine($"not response.IsSuccessStatusCode {response}");
            }*/
            return await GetPostsAsync();
            //return items;
        }
    }
}