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
    public class IndustrijaObuceService : IIndustrijaObuceService
    {
        public IndustrijaObuceRepository repository = new IndustrijaObuceRepository();
        public RadnikService radnikService = new RadnikService();
        public ObjekatService objekatService = new ObjekatService();
        public bool AddIndustrijaObuce(DTOIndustrijaObuce industrijaObuce)
        {
            IndustrijaObuce io = new IndustrijaObuce()
            {
                IdIO = industrijaObuce.IdIO,
                NazIO = industrijaObuce.NazIO
            };

            bool rez = repository.Insert(io);

            return rez;
        }

        public bool DeleteIndustrijaObuce(int id)
        {
            List<DTORadnik> radnici = radnikService.GetAllRadnik();
            foreach(DTORadnik r in radnici)
            {
                if(r.IdIO == id)
                {
                    radnikService.DeleteRadnik(r.IdRad, r.TipRad);
                }
            }

            List<DTOObjekat> objekti = objekatService.GetAllObjekat();
            foreach (DTOObjekat r in objekti)
            {
                if (r.IdIO == id)
                {
                    objekatService.DeleteObjekat(r.IdObj, r.IdIO, r.TipObj);
                }
            }
            return repository.Delete(id);
        }

        public DTOIndustrijaObuce FindByIDIndustrijaObuce(int id)
        {
            IndustrijaObuce io = repository.FindByID(id);
            DTOIndustrijaObuce dto = new DTOIndustrijaObuce()
            {
                IdIO = io.IdIO,
                NazIO = io.NazIO,
            };

            return dto;
        }

        public List<DTOIndustrijaObuce> GetAllIndustrijaObuce()
        {
            List<DTOIndustrijaObuce> dto = new List<DTOIndustrijaObuce>();
            List<IndustrijaObuce> io = repository.GetAll();

            foreach (IndustrijaObuce item in io)
            {
                DTOIndustrijaObuce d = new DTOIndustrijaObuce()
                {
                    IdIO = item.IdIO,
                    NazIO = item.NazIO,
                };
                dto.Add(d);
            }
            return dto;
        }

        public bool UpdateIndustrijaObuce(DTOIndustrijaObuce industrijaObuce)
        {
            IndustrijaObuce io = new IndustrijaObuce()
            {
                IdIO = industrijaObuce.IdIO,
                NazIO = industrijaObuce.NazIO,
            };
            return repository.Update(io);
        }
    }
}
