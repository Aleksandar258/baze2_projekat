using Servis2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Services.Interface
{
    public interface IRadnikService
    {
        bool AddRadnik(DTORadnik radnik);
        bool DeleteRadnik(int id, string tip);
        bool UpdateRadnik(DTORadnik radnik);
        List<DTORadnik> GetAllRadnik();
        DTORadnik FindByIDRadnik(int id);
    }
}
