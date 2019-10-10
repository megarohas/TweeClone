using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Abstract;
using WebApp.Models;

namespace WebApp.Data
{
    public class EfImgsRepository: IImgsRepository
    {
        private EfDbContext context;
        public EfImgsRepository()
        {
            context = new EfDbContext();
        }
        public IQueryable<Img> Imgs
        {
            get
            {
                return context.Imgs;
            }
        }


        public Img GetBy(string author)
        {
            List<Img> list = context.Imgs.ToList<Img>();
            Img Pic = list.Find(x => x.author == author);
            if (Pic == null)
                Pic = new Img { author = author, id = 123, image = new byte[1] { 255 } };
            return Pic;
        }

        public List<Img> GetByMany(List<string> authors)
        {
            List<Img> list = context.Imgs.ToList<Img>();
            List<Img> Pics = new List<Img> { };
            List<string> ListAuthors = new List<string> { };
                foreach (var item in list)
            {
                ListAuthors.Add(item.author);
            }
            for (int i = 0; i < authors.Count; i++)
            {

                if (ListAuthors.Contains(authors[i]))
                    Pics.Add(list.Find(x=>x.author == authors[i]));
                else
                {
                    Img Pic;
                    Pics.Add(Pic = new Img { author = authors[i], id = 123, image = new byte[1] { 255 } });
                }
            }
            Pics.Reverse();
            return Pics;
        }

        public bool AddImg(Img Pic)
        {
            List<Img> BD = context.Imgs.ToList();
            Img FindPic = BD.Find(x => x.author == Pic.author);
            if (FindPic != null)
            {
                context.Imgs.Remove(FindPic);
            }
            
            context.Imgs.Add(Pic);
            return context.SaveChanges() == 1;
        }
    }
}
