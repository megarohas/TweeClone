using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Abstract;
using WebApp.Models;

namespace WebApp.Data
{
    public class EfTweetsImgsRepository:ITweetsImgsRepository
    {
        private EfDbContext context;
        public EfTweetsImgsRepository()
        {
            context = new EfDbContext();
        }
        public IQueryable<TweetImg> TweetsImgs
        {
            get
            {
                return context.TweetsImgs;
            }
        }


        public List<TweetImg> GetBy(int tweeIDauthor)
        {
            List<TweetImg> list = context.TweetsImgs.ToList<TweetImg>();
            List<TweetImg> Pics = list.FindAll(x => x.tweeID == tweeIDauthor);
            if (Pics.Count == 0)
                return null;
            else
                return Pics;
            //Pic = new Img { author = author, id = 123, image = new byte[1] { 255 } };

        }

        public List<TweetImg> GetByMany(List<int> tweeIDs)
        {
            List<TweetImg> list = context.TweetsImgs.ToList<TweetImg>();
            List<TweetImg> Pics = new List<TweetImg> { };
            foreach (var item in list)
            {
                if(tweeIDs.Contains(item.tweeID))
                {
                    Pics.Add(item);
                }
            }


            Pics.Reverse();
            return Pics;
        }

        public bool AddImg(TweetImg Pic)
        {
            List<TweetImg> BD = context.TweetsImgs.ToList();
           // TweetImg FindPic = BD.Find(x => x.tweeID == Pic.tweeID);
           
            context.TweetsImgs.Add(Pic);
            return context.SaveChanges() == 1;
        }

    }
}