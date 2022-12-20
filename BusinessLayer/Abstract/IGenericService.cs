using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void Insert(T t);
        void Delete(T t);
        void Edit(T t);
        ICollection<T> GetAll();
        T GetById(int id);
    }
}
