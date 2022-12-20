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
    public class EfProductDetailRepository: EfGenericRepository<ProductDetail>,IProductDetailDal
    {
        ShoppingListContext context = new();
        public ProductDetail GetByName(string name)
        {
            return context.ProductDetails.SingleOrDefault(a => a.ProductName == name);
        }
    }
}
