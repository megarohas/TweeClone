using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }
        bool CreatePost(Post Tweet);
        List<Post> GetBy(string author);
        List<Post> GetByMany(List<string> authors);
    }
}
