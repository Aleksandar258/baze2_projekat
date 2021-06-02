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
    public class SastojiService : ISastojiService
    {
        public SastojiRepository repository = new SastojiRepository();
        public bool AddSastoji(DTOSastoji sastoji)
        {
            Sastoji io = new Sastoji()
            {
                NalaziMagacinMaterijalaIdObj = sastoji.IdObj,
                NalaziMagacinMaterijalaIndustrijaObuceIdIO = sastoji.IdIO,
                NalaziMaterijalIdMat = sastoji.IdMat,
                ObucaIdOb = sastoji.IdOb,
            };

            bool rez = repository.Insert(io);

            return rez;
        }

        public bool DeleteSastoji(int idObj, int idIO, int idMat, int idOb)
        {
            return repository.Delete(idObj, idIO, idMat, idOb);
        }

        public DTOSastoji FindByIDSastoji(int idObj, int idIO, int idMat, int idOb)
        {
            Sastoji io = repository.FindByID(idObj, idIO, idMat, idOb);
            DTOSastoji dto = new DTOSastoji()
            {
                IdObj = io.NalaziMagacinMaterijalaIdObj,
                IdIO = io.NalaziMagacinMaterijalaIndustrijaObuceIdIO,
                IdMat = io.NalaziMaterijalIdMat,
                IdOb = io.ObucaIdOb,
            };

            return dto;
        }

        public List<DTOSastoji> GetAllSastoji()
        {
            List<DTOSastoji> dto = new List<DTOSastoji>();
            List<Sastoji> io = repository.GetAll();

            foreach (Sastoji item in io)
            {
                DTOSastoji d = new DTOSastoji()
                {
                    IdObj = item.NalaziMagacinMaterijalaIdObj,
                    IdIO = item.NalaziMagacinMaterijalaIndustrijaObuceIdIO,
                    IdMat = item.NalaziMaterijalIdMat,
                    IdOb = item.ObucaIdOb,
                };
                dto.Add(d);
            }
            return dto;
        }

        public bool UpdateSastoji(DTOSastoji sastoji)
        {
            Sastoji io = new Sastoji()
            {
                NalaziMagacinMaterijalaIdObj = sastoji.IdObj,
                NalaziMagacinMaterijalaIndustrijaObuceIdIO = sastoji.IdIO,
                NalaziMaterijalIdMat = sastoji.IdMat,
                ObucaIdOb = sastoji.IdOb,
            };
            return repository.Update(io);
        }
    }
}
