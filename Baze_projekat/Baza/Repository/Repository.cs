using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza.Repository
{
    public class Repository<TModel> : IRepository<TModel> where TModel : class
    {

        public Repository()
        {

        }

        public virtual bool Delete(int id, int id2 = 0, int id3 = 0, int id4 = 0)
        {
            using(var db = new ModelFirstDbContext())
            {
                try
                {
                    DbSet<TModel> dbSet = db.Set<TModel>();
                    TModel entityToDelete;
                    if (id2 != 0)
                    {
                        entityToDelete = db.Set<TModel>().Find(id, id2);
                    } 
                    else
                    {
                        entityToDelete = db.Set<TModel>().Find(id);
                    }
                    db.Entry(entityToDelete).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Message: " + e.Message);
                    return false;
                }
            }
        }

        public virtual TModel FindByID(int id, int id2 = 0, int id3 = 0, int id4 = 0)
        {
            using(var db = new ModelFirstDbContext())
            {
                return db.Set<TModel>().Find(id);
            }
        }

        public virtual List<TModel> GetAll()
        {
            using (var db = new ModelFirstDbContext())
            {
                return db.Set<TModel>().ToList();
            }
        }

        public virtual bool Insert(TModel model)
        {
            using (var db = new ModelFirstDbContext())
            {
                try
                {
                    db.Set<TModel>().Add(model);
                    db.SaveChanges();
                    return true;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Message: " + e.Message);
                    return false;
                }
            }
        }

        public virtual bool Update(TModel model)
        {
            using (var db = new ModelFirstDbContext())
            {
                try
                {
                    db.Set<TModel>().Attach(model);
                    db.Entry(model).State = EntityState.Modified;
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
    }
}
