using Servis2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Services.Interface
{
    public interface ITipObuceService
    {
        bool AddTipObuce(DTOTipObuce tipObuce);
        bool DeleteTipObuce(int id);
        bool UpdateTipObuce(DTOTipObuce tipObuce);
        List<DTOTipObuce> GetAllTipObuce();
        DTOTipObuce FindByIDTipObuce(int id);
    }
}
