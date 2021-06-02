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
    public class NalaziService : INalzaiService
    {
        public NalaziRepository repository = new NalaziRepository();
        //public ObjekatService objekatService = new ObjekatService();
        //public MaterijalService materijalService = new MaterijalService();
        public bool AddNalazi(DTONalazi nalazi)
        {
            Nalazi io = new Nalazi()
            {
                MagacinMaterijalaIdObj = nalazi.IdObj,
                MagacinMaterijalaIndustrijaObuceIdIO = nalazi.IdIO,
                MaterijalIdMat = nalazi.IdMat,
            };

            bool rez = repository.Insert(io);

            return rez;
        }

        public bool DeleteNalazi(int idObj, int idIO, int idMat)
        {
            return repository.Delete(idObj, idIO, idMat);
        }

        public DTONalazi FindByIDNalazi(int id)
        {
            Nalazi nalazi = repository.FindByID(id);
            DTONalazi dto = new DTONalazi()
            {
                IdObj = nalazi.MagacinMaterijalaIdObj,
                IdIO = nalazi.MagacinMaterijalaIndustrijaObuceIdIO,
                IdMat = nalazi.MaterijalIdMat,
            };

            return dto;
        }

        public List<DTONalazi> GetAllNalazi()
        {
            List<DTONalazi> dto = new List<DTONalazi>();
            List<Nalazi> io = repository.GetAll();

            foreach (Nalazi nalazi in io)
            {
                DTONalazi d = new DTONalazi()
                {
                    IdObj = nalazi.MagacinMaterijalaIdObj,
                    IdIO = nalazi.MagacinMaterijalaIndustrijaObuceIdIO,
                    IdMat = nalazi.MaterijalIdMat,
                };
                dto.Add(d);
            }
            return dto;
        }

        public bool UpdateNalazi(DTONalazi nalazi)
        {
            Nalazi io = new Nalazi()
            {
                MagacinMaterijalaIdObj = nalazi.IdObj,
                MagacinMaterijalaIndustrijaObuceIdIO = nalazi.IdIO,
                MaterijalIdMat = nalazi.IdMat,
            };
            return repository.Update(io);
        }
    }
}
