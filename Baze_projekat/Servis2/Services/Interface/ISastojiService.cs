using Servis2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Services.Interface
{
    public interface ISastojiService
    {
        bool AddSastoji(DTOSastoji sastoji);
        bool DeleteSastoji(int idObj, int idIO, int idMat, int idOb);
        bool UpdateSastoji(DTOSastoji sastoji);
        List<DTOSastoji> GetAllSastoji();
        DTOSastoji FindByIDSastoji(int idObj, int idIO, int idMat, int idOb);
    }
}
