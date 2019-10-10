using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApp.Models;

namespace WebApp.Data
{
    public class EfDbContext: DbContext
    {
        public DbSet<ZablevaikiResponse> ZablevaikiResponses { get; set; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<Subscriber> Subscribers { set; get; }
        public DbSet<Img> Imgs { set; get; }
        public DbSet<TweetImg> TweetsImgs { set; get; }
    }
}