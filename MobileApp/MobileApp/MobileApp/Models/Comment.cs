using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class Comment
    {
        public User Author { get; set; }
        public List<string> Followers { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
    }
}