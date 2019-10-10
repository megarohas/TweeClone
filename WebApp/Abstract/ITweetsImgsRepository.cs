using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Abstract
{
    public interface ITweetsImgsRepository
    {
        IQueryable<TweetImg> TweetsImgs { get; }
        bool AddImg(TweetImg Tweet);
        List<TweetImg> GetBy(int tweeID);
        List<TweetImg> GetByMany(List<int> tweeIDs);
    }
}