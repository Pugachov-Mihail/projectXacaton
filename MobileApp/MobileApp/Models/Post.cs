using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class Post
    {
        public User Author { get; set; }
        public DateTime Date { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
