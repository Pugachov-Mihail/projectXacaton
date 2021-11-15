using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

public class Server
{
	private string rootUrl = "";

	public Server()
	{
	}

	public string GetRequest ()
    {
		string api = "/api/news/";
        string url = "https://b697-185-34-240-5.ngrok.io" + api;
        try
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            return response;
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

    public JToken Parse (string response)
    {
        return result = JToken.Parse(response);
    }
}