using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    class ItemParse
    {
        public int id { get; set; }
        public List<string> review { get; set; }
        public CratchClass user { get; set; }
        public string title { get; set; }
        public string news { get; set; }
        public string text { get; set; }
        public string date { get; set; }
        public bool publication { get; set; }
    }

    class CratchClass
    {
        public string username { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
}
