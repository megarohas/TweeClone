using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApp.Models;
using WebApp.Abstract;

namespace WebApp.Data
{
    public class EfSubscribersRepository:ISubscribersRepository
    {
        private EfDbContext context;
        public EfSubscribersRepository()
        {
            context = new EfDbContext();
        }
        public IQueryable<Subscriber> Subscribers {
            get
            {
                return context.Subscribers;
            }
        }
        public bool AddSub(Subscriber Sub)
        {

            List<Subscriber> list = context.Subscribers.ToList();
            if (!list.Contains(Sub))
                context.Subscribers.Add(Sub);

            return context.SaveChanges() == 1;
        }
        public bool DelSub(Subscriber Sub)
        {
            List<Subscriber> list = context.Subscribers.ToList();
            if (list.Contains(Sub))
                context.Subscribers.Remove(Sub);
            return context.SaveChanges() == 1;
        }

        public List<Subscriber> GetBy(string user)
        {
            List<Subscriber> list = context.Subscribers.ToList();
            List<Subscriber> Subs = list.FindAll(x => x.sub == user);
          
            return Subs;
        }
        public Subscriber GetSub(string sub, string target)
        {
            List<Subscriber> list = context.Subscribers.ToList();
            List<Subscriber> Sub = list.FindAll((x => x.sub == sub));
            Subscriber Subb = Sub.Find((x => x.target == target));
            return Subb;
        }
    }
}