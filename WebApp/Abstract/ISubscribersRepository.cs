using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Abstract
{
    public interface ISubscribersRepository
    {
        IQueryable<Subscriber> Subscribers { get; }
        bool AddSub(Subscriber Sub);
        bool DelSub(Subscriber Sub);
        Subscriber GetSub(string sub, string target);
        List<Subscriber> GetBy(string user);
        
    }
}