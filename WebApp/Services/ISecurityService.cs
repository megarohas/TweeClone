using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Services
{
    public interface ISecurityService
    {
        bool Authenticate(string username, string password);
        bool IsAuthenticated { get; }
        void Logout();
        int UserId { get; set; }
    }
}