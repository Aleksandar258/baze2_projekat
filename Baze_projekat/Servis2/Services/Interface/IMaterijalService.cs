using Servis2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Services.Interface
{
    public interface IMaterijalService
    {
        bool AddMaterijal(DTOMaterijal materijal);
        bool DeleteMaterijal(int id);
        bool UpdateMaterijal(DTOMaterijal materijal);
        List<DTOMaterijal> GetAllMaterijal();
        DTOMaterijal FindByIDMaterijal(int id);
    }
}
