using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Context;
using DTOLayer.DTOs.CategoryDTOs;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCategoryRepository: EfGenericRepository<Category>,ICategoryDal
    {
        ShoppingListContext context = new();
        public List<CategoryList> GetCategoryWithProducts()
        
        {
           List<CategoryList> categoryList =(from c in context.Categories
                                                    join p in context.Products 
                                                    on c.CategoryId equals p.CategoryId
                                                    group c by c.CategoryName into g
                                                    select new CategoryList
                                                      {
                                                          category = g.Key,
                                                          product = g.Count(),
                                                      }).ToList();
            return categoryList;
        }
        public Category GetByName(string name)
        {
            return context.Categories.SingleOrDefault(a => a.CategoryName == name);
        }
    }
}
