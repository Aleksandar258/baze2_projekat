using Servis2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Services.Interface
{
    public interface INalzaiService
    {
        bool AddNalazi(DTONalazi nalazi);
        bool DeleteNalazi(int idObj, int idIO, int idMat);
        bool UpdateNalazi(DTONalazi nalazi);
        List<DTONalazi> GetAllNalazi();
        DTONalazi FindByIDNalazi(int id);
    }
}
