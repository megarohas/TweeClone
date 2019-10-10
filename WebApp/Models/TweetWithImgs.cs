using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class TweetWithImgs
    {
        public Post Tweet { get; set; }

        public HttpPostedFileBase[] Imgs { get; set; }
    }
}