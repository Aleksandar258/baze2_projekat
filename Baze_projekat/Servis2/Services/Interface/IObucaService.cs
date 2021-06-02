using Servis2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Services.Interface
{
    public interface IObucaService
    {
        bool AddObuca(DTOObuca obuca);
        bool DeleteObuca(int id);
        bool UpdateObuca(DTOObuca obuca);
        List<DTOObuca> GetAllObuca();
        DTOObuca FindByIDObuca(int id);
    }
}
