using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Globalization;
using System.Transactions;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfGenericRepository<T>: IGenericDal<T> where T:class
    {
        ShoppingListContext context = new();
        public void Insert(T t)
        {
            var entity=context.Entry(t);
            entity.State = EntityState.Added;
            context.SaveChanges(); 
        }

        public void Delete(T t)
        {
            var entity = context.Entry(t);
            entity.State=EntityState.Deleted;
            context.SaveChanges();
        }

        public ICollection<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public void Edit(T t)
        {
            
            int updates = context.SaveChanges();
       
            var entity = context.Entry(t);
            entity.State = EntityState.Modified;
            context.SaveChanges();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
       
    }
}
