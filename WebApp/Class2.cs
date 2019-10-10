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

namespace Class2
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString ImageSmall(this HtmlHelper html, byte[] image)
        {
            
            if (image.Count() == 1)
            {
                return new MvcHtmlString("<img src='/Content/img/up2.jpg' class='round' width=50 height=50 >");
            }
            else
            {
                var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
                return new MvcHtmlString("<img src='" + img + " ' class='round' " + "width = " + 50 + " height = " + 50 + " />");
            }
        }

        public static MvcHtmlString ImageSmall2(this HtmlHelper html, byte[] image)
        {

            if (image.Count() == 1)
            {
                return new MvcHtmlString("");
            }
            else
            {
                var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
                return new MvcHtmlString("'" + img + " ' class='' " + "width = " + 20 + " height = " + 20 + " ");
            }
        }


        public static MvcHtmlString ImageSmall3(this HtmlHelper html, byte[] image)
        {

            if (image.Count() == 1)
            {
                return new MvcHtmlString("");
            }
            else
            {
                var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
                return new MvcHtmlString("<img src='" + img + " ' class='' " + "width = " + 40 + " height = " + 40 + " />");
            }
        }
    }
}