using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        AppDbContext context = new AppDbContext(); 
        private readonly DbSet<T> _object;         

        public GenericRepository()
        {
            _object = context.Set<T>(); 
        }

        public void Delete(int id)
        {
            var entity = _object.Find(id);
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges(); 
            }
        }

        public List<T> GetAll()
        {
            return _object.ToList(); 
        }

        public T GetById(int id)
        {
            return _object.Find(id); 
        }

        public void Insert(T entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges(); 
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges(); 
        }

    }
}
