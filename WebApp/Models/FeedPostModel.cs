using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Models
{
    public class FeedPostModel
    {
        public List<Post> FeedPost { get; set; }
        public List<Img> FeedPic { get; set; }
        public List<TweetImg> TweeImgs { get; set; }
    }
}