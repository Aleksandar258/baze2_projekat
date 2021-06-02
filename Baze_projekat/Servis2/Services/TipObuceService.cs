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
    public class TipObuceService : ITipObuceService
    {
        public TipObuceRepository repository = new TipObuceRepository();
        public ObucaService obucaService = new ObucaService();
        public bool AddTipObuce(DTOTipObuce tipObuce)
        {
            TipObuce io = new TipObuce()
            {
                IdTipOb = tipObuce.IdTipOb,
                NazTip = tipObuce.NazTip
            };

            bool rez = repository.Insert(io);

            return rez;
        }

        public bool DeleteTipObuce(int id)
        {
            List<DTOObuca> nalazis = obucaService.GetAllObuca();
            foreach (DTOObuca r in nalazis)
            {
                if (r.IdTip == id)
                {
                    obucaService.DeleteObuca(r.IdOb);
                }
            }
            return repository.Delete(id);
        }

        public DTOTipObuce FindByIDTipObuce(int id)
        {
            TipObuce io = repository.FindByID(id);
            DTOTipObuce dto = new DTOTipObuce()
            {
                IdTipOb = io.IdTipOb,
                NazTip = io.NazTip,
            };

            return dto;
        }

        public List<DTOTipObuce> GetAllTipObuce()
        {
            List<DTOTipObuce> dto = new List<DTOTipObuce>();
            List<TipObuce> io = repository.GetAll();

            foreach (TipObuce item in io)
            {
                DTOTipObuce d = new DTOTipObuce()
                {
                    IdTipOb = item.IdTipOb,
                    NazTip = item.NazTip,
                };
                dto.Add(d);
            }
            return dto;
        }

        public bool UpdateTipObuce(DTOTipObuce tipObuce)
        {
            TipObuce io = new TipObuce()
            {
                IdTipOb = tipObuce.IdTipOb,
                NazTip = tipObuce.NazTip,
            };
            return repository.Update(io);
        }
    }
}
