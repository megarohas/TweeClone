using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Img
    {
       
        public byte[] image { get; set; }
       
        public string author { get; set; }

        public int id { get; set; }
    }
}