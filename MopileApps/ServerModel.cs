using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace MopileApps
{
    //Класс серверный
    class ServerModel
    {
        public class Server
        {
            //Принимает урл сервера.
            //Тестовый сервер принимает сводку новостей
            const string Url = "http://127.0.0.1:8000/api/news/";


            JsonSerializerOptions option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            // Настройка клиента 
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        //Расшифровка json 
        public async Task<IEnumerable<StartPage>> Get()
            {
                HttpClient client = GetClient();
                string result = await client.GetStringAsync(Url);
                return JsonSerializer.Deserialize<IEnumerable<StartPage>>(result, option);
            }
            public async Task<StartPage> Update(StartPage friend)
            {
                HttpClient client = GetClient();
                var response = await client.PutAsync(Url,
                    new StringContent(
                        JsonSerializer.Serialize(friend),
                        Encoding.UTF8, "application/json"));

                if (response.StatusCode != HttpStatusCode.OK)
                    return null;

                return JsonSerializer.Deserialize<StartPage>(
                    await response.Content.ReadAsStringAsync(), option);
            }
            // удаляем друга
            public async Task<StartPage> Delete(int id)
            {
                HttpClient client = GetClient();
                var response = await client.DeleteAsync(Url + id);
                if (response.StatusCode != HttpStatusCode.OK)
                    return null;

                return JsonSerializer.Deserialize<StartPage>(
                   await response.Content.ReadAsStringAsync(), option);
            }

        }
    }
}
