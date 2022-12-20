using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfProductRepository: EfGenericRepository<Product>,IProductDal
    {
        ShoppingListContext context = new();
        public Product GetByName(string name)
        {
            return context.Products.SingleOrDefault(a => a.ProductName == name);
        }

        public List<Product> GetProductWithList()
        {
            return context.Products.Include(a=>a.ListProducts).ToList();
        }
    }
}
