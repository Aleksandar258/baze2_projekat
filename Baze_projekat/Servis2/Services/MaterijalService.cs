using Baza;
using Baza.Repository;
using Servis2.Model;
using Servis2.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Services
{
    public class MaterijalService : IMaterijalService
    {
        public MaterijalRepository repository = new MaterijalRepository();
        public bool AddMaterijal(DTOMaterijal materijal)
        {
            Materijal io = new Materijal()
            {
                IdMat = materijal.IdMat,
                NazMat = materijal.NazMat
            };

            bool rez = repository.Insert(io);

            return rez;
        }

        public bool DeleteMaterijal(int id)
        {
            return repository.Delete(id);
        }

        public DTOMaterijal FindByIDMaterijal(int id)
        {
            Materijal io = repository.FindByID(id);
            DTOMaterijal dto = new DTOMaterijal()
            {
                IdMat = io.IdMat,
                NazMat = io.NazMat,
            };

            return dto;
        }

        public List<DTOMaterijal> GetAllMaterijal()
        {
            List<DTOMaterijal> dto = new List<DTOMaterijal>();
            List<Materijal> io = repository.GetAll();

            foreach (Materijal item in io)
            {
                DTOMaterijal d = new DTOMaterijal()
                {
                    IdMat = item.IdMat,
                    NazMat = item.NazMat,
                };
                dto.Add(d);
            }
            return dto;
        }

        public bool UpdateMaterijal(DTOMaterijal materijal)
        {
            Materijal io = new Materijal()
            {
                IdMat = materijal.IdMat,
                NazMat = materijal.NazMat,
            };
            return repository.Update(io);
        }
    }
}
