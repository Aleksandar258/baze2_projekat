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
    public class ObjekatService : IObjekatService
    {
        public ObjekatRepository repository = new ObjekatRepository();
        public MagacinMaterijalaRepository repositoryM = new MagacinMaterijalaRepository();
        public ProdavnicaRepository repositoryP = new ProdavnicaRepository();
        public bool AddObjekat(DTOObjekat objekat)
        {
            if (objekat.TipObj == "MagacinMaterijala")
            {
                MagacinMaterijala p = new MagacinMaterijala()
                {
                    IdObj = objekat.IdObj,
                    NazObj = objekat.NazObj,
                    AdrObj = objekat.AdrObj,
                    TipObj = objekat.TipObj,
                    IndustrijaObuceIdIO = objekat.IdIO,
                    GradIdG = objekat.IdG,
                };
                return repositoryM.Insert(p);
            }
            else if (objekat.TipObj == "Prodavnica")
            {
                Prodavnica o = new Prodavnica()
                {
                    IdObj = objekat.IdObj,
                    NazObj = objekat.NazObj,
                    AdrObj = objekat.AdrObj,
                    TipObj = objekat.TipObj,
                    IndustrijaObuceIdIO = objekat.IdIO,
                    GradIdG = objekat.IdG,
                };
                return repositoryP.Insert(o);
            }
            else
            {
                return false;
            }
        }

        public bool DeleteObjekat(int id, int id2, string tip)
        {
            if (tip == "MagacinMaterijala")
            {
                return repositoryM.Delete(id, id2);
            }
            else if (tip == "Prodavnica")
            {
                return repositoryP.Delete(id, id2);
            }
            else
            {
                return false;
            }
        }

        public DTOObjekat FindByIDObjekat(int id)
        {
            Objekat objekat = repository.FindByID(id);
            DTOObjekat dto = new DTOObjekat()
            {
                IdObj = objekat.IdObj,
                NazObj = objekat.NazObj,
                AdrObj = objekat.AdrObj,
                TipObj = objekat.TipObj,
                IdIO = objekat.IndustrijaObuceIdIO,
                IdG = objekat.GradIdG,
            };

            return dto;
        }

        public List<DTOObjekat> GetAllObjekat()
        {
            List<DTOObjekat> dto = new List<DTOObjekat>();
            List<Objekat> io = repository.GetAll();

            foreach (Objekat objekat in io)
            {
                DTOObjekat d = new DTOObjekat()
                {
                    IdObj = objekat.IdObj,
                    NazObj = objekat.NazObj,
                    AdrObj = objekat.AdrObj,
                    TipObj = objekat.TipObj,
                    IdIO = objekat.IndustrijaObuceIdIO,
                    IdG = objekat.GradIdG,
                };
                dto.Add(d);
            }
            return dto;
        }

        public bool UpdateObjekat(DTOObjekat objekat)
        {
            if (objekat.TipObj == "MagacinMaterijala")
            {
                MagacinMaterijala p = new MagacinMaterijala()
                {
                    IdObj = objekat.IdObj,
                    NazObj = objekat.NazObj,
                    AdrObj = objekat.AdrObj,
                    TipObj = objekat.TipObj,
                    IndustrijaObuceIdIO = objekat.IdIO,
                    GradIdG = objekat.IdG,
                };
                return repositoryM.Update(p);
            }
            else if (objekat.TipObj == "Prodavnica")
            {
                Prodavnica o = new Prodavnica()
                {
                    IdObj = objekat.IdObj,
                    NazObj = objekat.NazObj,
                    AdrObj = objekat.AdrObj,
                    TipObj = objekat.TipObj,
                    IndustrijaObuceIdIO = objekat.IdIO,
                    GradIdG = objekat.IdG,
                };
                return repositoryP.Update(o);
            }
            else
            {
                return false;
            }
        }
    }
}
