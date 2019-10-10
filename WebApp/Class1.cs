using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Abstract;
using WebApp.Data;
using System.Web.Helpers;
using System.Web.SessionState;
using WebApp.Services;
using System.Text;
using System.Threading;

namespace Class1
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper html, byte[] image)
        {
            
            if (image.Count() == 1)
            {
                return new MvcHtmlString("<img src='/Content/img/up2.jpg'>");
            }
            else
            {
                var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
                return new MvcHtmlString("<img src='" + img + " '" + "width = " + 300 + " height = " + 300 + " />");
            }
        }
    }
}