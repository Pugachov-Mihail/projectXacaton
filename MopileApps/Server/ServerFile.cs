using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MopileApps.Server
{
    public class ServerFile
    {
        public string response = "";
        public JToken result = "";

        public ServerFile()
        {
        }

        public async Task<ViewNews> GetRequest(string api)
        {
            string url = "https://18ce-185-34-240-5.ngrok.io" + api;
            try
            {
                HttpClient client = new HttpClient();
                this.response = await client.GetStringAsync(url);
                return new ViewNews();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); return null; }
        }

        public void Post(string url)
        {

        }

        public void PutRequest(string url)
        {

        }

        public void Delete(string url)
        {

        }
    }
}