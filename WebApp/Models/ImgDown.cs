using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ImgDown
    {
        [Required(ErrorMessage = "Пожалуйста, выберите фото")]
        public HttpPostedFileBase image { get; set; }
       
        
    }
}