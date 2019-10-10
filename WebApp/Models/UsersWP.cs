using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Data;

namespace WebApp.Models
{
    public class UsersWP
    {
        public List<ZablevaikiResponse> Usrs { get; set; }
        public List<Img> Pics { get; set; }
    }
}