using DTOLayer.DTOs.CategoryDTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        List<CategoryList> GetCategoryWithProducts();
        Category GetByName(string categoryName);
    }
}
