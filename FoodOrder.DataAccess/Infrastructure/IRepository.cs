using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.DataAccess.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Find(object Id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Delete(object Id);
        int SaveChanges();
    }
}
