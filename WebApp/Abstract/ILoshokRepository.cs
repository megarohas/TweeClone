using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Abstract
{
    public interface ILoshokRepository
    {
        IQueryable<ZablevaikiResponse> Loshki { get; }
        bool CreateLoshok(ZablevaikiResponse losh);
        ZablevaikiResponse GetBy(string login);
        List<ZablevaikiResponse> GetAll();
    }
}
