using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

public class Server
{
	private string rootUrl = "";
    public string response = "";
    public JToken result = "";

	public Server()
	{
	}

	public async void GetRequest (string api)
    {
        string url = "https://acf5-185-34-240-5.ngrok.io" + api;
        try
        {
            HttpClient client = new HttpClient();
            this.response = await client.GetStringAsync(url);
        }
        catch (Exception ex)
        { Console.WriteLine(ex.Message); }
    }

    public void Post (string url)
    {

    }

    public void PutRequest (string url)
    {

    }

    public void Delete (string url)
    {

    }

    public JToken ServerParse (string response)
    {
        try
        {
            this.result = JToken.Parse(response);
            return this.result;
        }
        catch (Exception ex)
        { 
            Console.WriteLine(ex.Message);
            return this.result;
        }
    }
}