using Servis2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Services.Interface
{
    public interface IObjekatService
    {
        bool AddObjekat(DTOObjekat objekat);
        bool DeleteObjekat(int id, int id2, string tip);
        bool UpdateObjekat(DTOObjekat objekat);
        List<DTOObjekat> GetAllObjekat();
        DTOObjekat FindByIDObjekat(int id);
    }
}
