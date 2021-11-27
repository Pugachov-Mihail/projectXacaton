using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Bio { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public List<string> Followers { get; set; }
        public List<string> Subscribe { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
