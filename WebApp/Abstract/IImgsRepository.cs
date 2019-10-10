using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Abstract
{
    public interface IImgsRepository
    {
        IQueryable<Img> Imgs { get; }
        bool AddImg(Img Pic);
        Img GetBy(string author);
        List<Img> GetByMany(List<string> authors);
    }
}
