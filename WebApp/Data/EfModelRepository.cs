using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Abstract;
using WebApp.Models;

namespace WebApp.Data
{
    public class EfModelRepository : ILoshokRepository
    {
        private EfDbContext context;
        public EfModelRepository()
        {
            context = new EfDbContext();
        }
        public IQueryable<ZablevaikiResponse> Loshki
        {
            get
            {
                return context.ZablevaikiResponses;
            }
        }


        public ZablevaikiResponse GetBy(string username)
        {
            List<ZablevaikiResponse> list = context.ZablevaikiResponses.ToList<ZablevaikiResponse>();
            ZablevaikiResponse user = list.Find(x => x.Login == username);
            return user;
        }

        public bool CreateLoshok(ZablevaikiResponse losh)
        {
            context.ZablevaikiResponses.Add(losh);
            return context.SaveChanges() == 1;
        }

        public List<ZablevaikiResponse> GetAll()
        {
            return context.ZablevaikiResponses.ToList();
        }
    }
}