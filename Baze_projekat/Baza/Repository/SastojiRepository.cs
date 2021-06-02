using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza.Repository
{
    public class SastojiRepository : Repository<Sastoji>
    {
        public override bool Delete(int id, int id2 = 0, int id3 = 0, int id4 = 0)
        {
            using (var db = new ModelFirstDbContext())
            {
                try
                {
                    DbSet<Sastoji> dbSet = db.Set<Sastoji>();
                    Sastoji entityToDelete;
                    entityToDelete = db.Set<Sastoji>().FirstOrDefault(item => item.NalaziMagacinMaterijalaIdObj == id && item.NalaziMagacinMaterijalaIndustrijaObuceIdIO== id2 && item.NalaziMaterijalIdMat == id3 && item.ObucaIdOb == id4);
                    db.Entry(entityToDelete).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Message: " + e.Message);
                    return false;
                }
            }
        }

        public override Sastoji FindByID(int id, int id2 = 0, int id3 = 0, int id4 = 0)
        {
            using (var db = new ModelFirstDbContext())
            {
                return db.Set<Sastoji>().FirstOrDefault(item => item.NalaziMagacinMaterijalaIdObj == id && item.NalaziMagacinMaterijalaIndustrijaObuceIdIO == id2 && item.NalaziMaterijalIdMat == id3 && item.ObucaIdOb == id4);
            }
        }
    }
}
