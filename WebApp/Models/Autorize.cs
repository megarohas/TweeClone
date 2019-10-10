using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Autorize
    {
        [Required(ErrorMessage = "Пожалуйста, введите логин")]
        public string login { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите пассворд")]
        public string password { get; set; }
    }
}