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

        public bool Delete(int id)
        {
            using(var db = new ModelFirstDbContext())
            {
                try
                {
                    DbSet<TModel> dbSet = db.Set<TModel>();
                    TModel entityToDelete = db.Set<TModel>().Find(id);
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

        public TModel FindByID(int id)
        {
            using(var db = new ModelFirstDbContext())
            {
                return db.Set<TModel>().Find(id);
            }
        }

        public List<TModel> GetAll()
        {
            using (var db = new ModelFirstDbContext())
            {
                return db.Set<TModel>().ToList();
            }
        }

        public bool Insert(TModel model)
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

        public bool Update(TModel model)
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
