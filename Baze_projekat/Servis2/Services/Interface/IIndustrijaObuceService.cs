using Servis2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Services.Interface
{
    public interface IIndustrijaObuceService
    {
        bool AddIndustrijaObuce(DTOIndustrijaObuce industrijaObuce);
        bool DeleteIndustrijaObuce(int id);
        bool UpdateIndustrijaObuce(DTOIndustrijaObuce industrijaObuce);
        List<DTOIndustrijaObuce> GetAllIndustrijaObuce();
        DTOIndustrijaObuce FindByIDIndustrijaObuce(int id);
    }
}

