using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using MobileApp.Models;
using System.Diagnostics;
using Newtonsoft.Json;


namespace MobileApp.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Author="This is an item description." },
            
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            Debug.WriteLine("STOP");
            HttpClient client = new HttpClient();
            string api = "api/news/";
            string url = "https://cb3e-185-34-240-5.ngrok.io/";
            Debug.WriteLine("STOP");
            HttpResponseMessage response = await client.GetAsync(url + api);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Item a = JsonConvert.DeserializeObject<Item>(content);
                items.Add(a);
            }
            else
            {
                Debug.WriteLine($"not response.IsSuccessStatusCode {response}");
                Item a = new Item { Id = "2", Text = "Second item", Author = "aut" };
                items.Add(a);
            }
            return await Task.FromResult(items);
        }
    }
}