using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfListRepository: EfGenericRepository<List>,IListDal
    {
        ShoppingListContext context = new();
        public List GetByName(string name)
        {
            return context.Lists.SingleOrDefault(a => a.ListName == name);
        }
    }
}
