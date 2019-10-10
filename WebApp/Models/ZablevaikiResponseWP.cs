using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.Models
{
    public class ZablevaikiResponseWP
    {
        public ZablevaikiResponse USER { get; set; }
        public Img UP { get; set; }
        public List<TweetImg> Imgs { get; set; }
        public List<Post> Tweets { get; set; }

    }
}