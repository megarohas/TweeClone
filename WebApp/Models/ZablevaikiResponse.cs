using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ZablevaikiResponse
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите свое имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите, Да или Нет")]
        public bool? UsePersData { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите пассворд")]
        public string Password { get; set; }
    }
}