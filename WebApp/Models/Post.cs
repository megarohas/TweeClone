using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Post
    {
        [Required(ErrorMessage = "Пожалуйста, введите текст поста")]
        public string text { get; set; }
       
        public string author { get; set; }

        public int id { get; set; }

        
    }
}