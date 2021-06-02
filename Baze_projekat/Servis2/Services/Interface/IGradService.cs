using Servis2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Services.Interface
{
    public interface IGradService
    {
        bool AddGrad(DTOGrad grad);
        bool DeleteGrad(int id);
        bool UpdateGrad(DTOGrad grad);
        List<DTOGrad> GetAllGrad();
        DTOGrad FindByIDGrad(int id);
    }
}
