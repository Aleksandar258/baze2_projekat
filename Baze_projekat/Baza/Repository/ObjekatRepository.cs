using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza.Repository
{
    public class ObjekatRepository : Repository<Objekat>
    {
        public override bool Delete(int id, int id2 = 0, int id3 = 0, int id4 = 0)
        {
            using (var db = new ModelFirstDbContext())
            {
                try
                {
                    DbSet<Objekat> dbSet = db.Set<Objekat>();
                    Objekat entityToDelete;
                    entityToDelete = db.Set<Objekat>().FirstOrDefault(item => item.IdObj == id && item.IndustrijaObuceIdIO == id2);
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

        public override Objekat FindByID(int id, int id2 = 0, int id3 = 0, int id4 = 0)
        {
            using (var db = new ModelFirstDbContext())
            {
                return db.Set<Objekat>().FirstOrDefault(item => item.IdObj == id && item.IndustrijaObuceIdIO == id2);
            }
        }
    }
}
