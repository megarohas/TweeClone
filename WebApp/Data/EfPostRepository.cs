using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Abstract;
using WebApp.Models;

namespace WebApp.Data
{
    public class EfPostRepository: IPostRepository
    {
        private EfDbContext context;
        public EfPostRepository()
        {
            context = new EfDbContext();
        }
        public IQueryable<Post> Posts
        {
            get
            {
                return context.Posts;
            }
        }


        public List<Post> GetBy(string author)
        {
            List<Post> list = context.Posts.ToList<Post>();
            List<Post> Tweets = list.FindAll(x => x.author == author);
            Tweets.Reverse();
            return Tweets;
        }

        public List<Post> GetByMany(List<string> authors)
        {
            List<Post> list = context.Posts.ToList<Post>();
            List<Post> Tweets = new List<Post> { };
            for (int i = 0; i < list.Count; i++)
            {
                if (authors.Contains(list[i].author))
                    Tweets.Add(list[i]);
            }
            Tweets.Reverse();
            return Tweets;
        }

        public bool CreatePost(Post Tweet)
        {
            context.Posts.Add(Tweet);
            return context.SaveChanges() == 1;
        }
    }
}
