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
    public class RadnikService : IRadnikService
    {
        public RadnikRepository repository = new RadnikRepository();
        public ProdavacRepository repositoryP = new ProdavacRepository();
        public ObucarRepository repositoryO = new ObucarRepository();

        public bool AddRadnik(DTORadnik radnik)
        {
            /*Radnik r = new Radnik()
            {
                IdRad = radnik.IdRad,
                imeRad = radnik.ImeRad,
                PrzRad = radnik.PrzRad,
                PltRad = radnik.PltRad,
                TipRad = radnik.TipRad,
            };*/

            if(radnik.TipRad == "Prodavac")
            {
                Prodavac p = new Prodavac()
                {
                    IdRad = radnik.IdRad,
                    imeRad = radnik.ImeRad,
                    PrzRad = radnik.PrzRad,
                    PltRad = radnik.PltRad,
                    TipRad = radnik.TipRad,
                    IndustrijaObuceIdIO = radnik.IdIO,
                };
                return repositoryP.Insert(p);
            }
            else if(radnik.TipRad == "Obucar")
            {
                Obucar o = new Obucar()
                {
                    IdRad = radnik.IdRad,
                    imeRad = radnik.ImeRad,
                    PrzRad = radnik.PrzRad,
                    PltRad = radnik.PltRad,
                    TipRad = radnik.TipRad,
                    IndustrijaObuceIdIO = radnik.IdIO,
                };
                return repositoryO.Insert(o);
            }
            else
            {
                return false;
            }
        }

        public bool DeleteRadnik(int id, string tip)
        {
            if(tip == "Prodavac")
            {
                return repositoryP.Delete(id);
            }
            else if(tip == "Obucar")
            {
                return repositoryO.Delete(id);
            }
            else
            {
                return false;
            }
        }

        public DTORadnik FindByIDRadnik(int id)
        {
            Radnik radnik = repository.FindByID(id);
            DTORadnik dto = new DTORadnik()
            {
                IdRad = radnik.IdRad,
                ImeRad = radnik.imeRad,
                PrzRad = radnik.PrzRad,
                PltRad = radnik.PltRad,
                TipRad = radnik.TipRad,
                IdIO = radnik.IndustrijaObuceIdIO,
            };

            return dto;
        }

        public List<DTORadnik> GetAllRadnik()
        {
            List<DTORadnik> dto = new List<DTORadnik>();
            List<Radnik> io = repository.GetAll();

            foreach (Radnik radnik in io)
            {
                DTORadnik d = new DTORadnik()
                {
                    IdRad = radnik.IdRad,
                    ImeRad = radnik.imeRad,
                    PrzRad = radnik.PrzRad,
                    PltRad = radnik.PltRad,
                    TipRad = radnik.TipRad,
                    IdIO = radnik.IndustrijaObuceIdIO,
                };
                dto.Add(d);
            }
            return dto;
        }

        public bool UpdateRadnik(DTORadnik radnik)
        {
            if (radnik.TipRad == "Prodavac")
            {
                Prodavac p = new Prodavac()
                {
                    IdRad = radnik.IdRad,
                    imeRad = radnik.ImeRad,
                    PrzRad = radnik.PrzRad,
                    PltRad = radnik.PltRad,
                    TipRad = radnik.TipRad,
                    IndustrijaObuceIdIO = radnik.IdIO,
                };
                return repositoryP.Update(p);
            }
            else if (radnik.TipRad == "Obucar")
            {
                Obucar o = new Obucar()
                {
                    IdRad = radnik.IdRad,
                    imeRad = radnik.ImeRad,
                    PrzRad = radnik.PrzRad,
                    PltRad = radnik.PltRad,
                    TipRad = radnik.TipRad,
                    IndustrijaObuceIdIO = radnik.IdIO,
                };
                return repositoryO.Update(o);
            }
            else
            {
                return false;
            }
        }
    }
}
