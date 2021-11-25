using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MopileApps.Server
{
    class ParserJson
    {
        public JToken ServerParse(string response)
        {
            try
            {
                string result = (string)JToken.Parse(response);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
