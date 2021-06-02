using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza.Repository
{
    public interface IRepository<TModel> where TModel : class
    {
        List<TModel> GetAll();
        TModel FindByID(int id, int id2 = 0, int id3 = 0, int id4 = 0);
        bool Insert(TModel model);
        bool Delete(int id, int id2 = 0, int id3 = 0, int id4 = 0);
        bool Update(TModel model);
    }
}
