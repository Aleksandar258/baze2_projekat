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
    public class ObucaService : IObucaService
    {
        public ObucaRepository repository = new ObucaRepository();
        public SastojiService sastojiService = new SastojiService();
        public bool AddObuca(DTOObuca obuca)
        {
            Obuca io = new Obuca()
            {
                IdOb = obuca.IdOb,
                NazOb = obuca.NazOb,
                BrOb = obuca.BrOb,
                CenaOb = obuca.CenaOb,
                TipObuceIdTipOb = obuca.IdTip,
            };

            bool rez = repository.Insert(io);

            return rez;
        }

        public bool DeleteObuca(int id)
        {
            List<DTOSastoji> nalazis = sastojiService.GetAllSastoji();
            foreach (DTOSastoji r in nalazis)
            {
                if (r.IdOb == id)
                {
                    sastojiService.DeleteSastoji(r.IdObj, r.IdIO, r.IdMat, r.IdOb);
                }
            }
            return repository.Delete(id);
        }

        public DTOObuca FindByIDObuca(int id)
        {
            Obuca io = repository.FindByID(id);
            DTOObuca dto = new DTOObuca()
            {
                IdOb = io.IdOb,
                NazOb = io.NazOb,
                BrOb = io.BrOb,
                CenaOb = io.CenaOb,
                IdTip = io.TipObuceIdTipOb,
            };

            return dto;
        }

        public List<DTOObuca> GetAllObuca()
        {
            List<DTOObuca> dto = new List<DTOObuca>();
            List<Obuca> io = repository.GetAll();

            foreach (Obuca item in io)
            {
                DTOObuca d = new DTOObuca()
                {
                    IdOb = item.IdOb,
                    NazOb = item.NazOb,
                    BrOb = item.BrOb,
                    CenaOb = item.CenaOb,
                    IdTip = item.TipObuceIdTipOb
                };
                dto.Add(d);
            }
            return dto;
        }

        public bool UpdateObuca(DTOObuca obuca)
        {
            Obuca io = new Obuca()
            {
                IdOb = obuca.IdOb,
                NazOb = obuca.NazOb,
                BrOb = obuca.BrOb,
                CenaOb = obuca.CenaOb,
                TipObuceIdTipOb = obuca.IdTip,
            };
            return repository.Update(io);
        }
    }
}
