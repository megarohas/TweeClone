using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.SessionState;
using WebApp.Models;
using WebApp.Abstract;
using WebApp.Data;


namespace WebApp.Services
{
    public class SecurityService
    {
        static public EfModelRepository Users;
        public static HttpSessionState Session;
        
        public static bool Authenticate(string login, string password)
        {
            var user = Users.GetBy(login);

            if (user == null)
            {
                return false;
            }
            return (user.Password == password);
        }

        public static bool IsAuthenticated
        {
            get { return UserId != "0"; }
        }

        public static void Logout()
        {
            Session.Abandon();
        }

        public static string UserId
        {
            get
            {
                if (Session["UserId"] != null)
                    return Session["UserId"].ToString();
                else
                    return "0";
            }
            set
            {
                Session["UserId"] = value;
            }
        }

        public static void Login(ZablevaikiResponse user)
        {
            Session["UserId"] = user.Login;
        }

    }
}