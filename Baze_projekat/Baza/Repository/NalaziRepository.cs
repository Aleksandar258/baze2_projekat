using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza.Repository
{
    public class NalaziRepository : Repository<Nalazi>
    {
        public override bool Delete(int id, int id2 = 0, int id3 = 0, int id4 = 0)
        {
            using (var db = new ModelFirstDbContext())
            {
                try
                {
                    DbSet<Nalazi> dbSet = db.Set<Nalazi>();
                    Nalazi entityToDelete;
                    entityToDelete = db.Set<Nalazi>().FirstOrDefault(item => item.MagacinMaterijalaIdObj == id && item.MagacinMaterijalaIndustrijaObuceIdIO == id2 && item.MaterijalIdMat == id3);
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

        public override Nalazi FindByID(int id, int id2 = 0, int id3 = 0, int id4 = 0)
        {
            using (var db = new ModelFirstDbContext())
            {
                return db.Set<Nalazi>().FirstOrDefault(item => item.MagacinMaterijalaIdObj == id && item.MagacinMaterijalaIndustrijaObuceIdIO == id2 && item.MaterijalIdMat == id3);
            }
        }
    }
}
