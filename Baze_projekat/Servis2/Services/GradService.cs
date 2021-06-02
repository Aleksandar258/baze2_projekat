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
    public class GradService : IGradService
    {
        public ObjekatService objekatService = new ObjekatService();

        public GradRepository repository = new GradRepository();
        public bool AddGrad(DTOGrad grad)
        {
            Grad io = new Grad()
            {
                IdG = grad.IdG,
                NazG = grad.NazG
            };

            bool rez = repository.Insert(io);

            return rez;
        }

        public bool DeleteGrad(int id)
        {
            List<DTOObjekat> objekti = objekatService.GetAllObjekat();
            foreach (DTOObjekat r in objekti)
            {
                if (r.IdG == id)
                {
                    objekatService.DeleteObjekat(r.IdObj, r.IdIO, r.TipObj);
                }
            }
            return repository.Delete(id);
        }

        public DTOGrad FindByIDGrad(int id)
        {
            Grad io = repository.FindByID(id);
            DTOGrad dto = new DTOGrad()
            {
                IdG = io.IdG,
                NazG = io.NazG,
            };

            return dto;
        }

        public List<DTOGrad> GetAllGrad()
        {
            List<DTOGrad> dto = new List<DTOGrad>();
            List<Grad> io = repository.GetAll();

            foreach (Grad item in io)
            {
                DTOGrad d = new DTOGrad()
                {
                    IdG = item.IdG,
                    NazG = item.NazG,
                };
                dto.Add(d);
            }
            return dto;
        }

        public bool UpdateGrad(DTOGrad grad)
        {
            Grad io = new Grad()
            {
                IdG = grad.IdG,
                NazG = grad.NazG,
            };
            return repository.Update(io);
        }
    }
}
