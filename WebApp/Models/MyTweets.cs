using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Data;

namespace WebApp.Models
{
    public class PostsFromOne
    {
        public string author { get; set; }
        public List<Post> Posts { get; set; }
        public Byte[] Ava { get; set; }
        public List<TweetImg> TweeImgs { get; set; }

    }
}