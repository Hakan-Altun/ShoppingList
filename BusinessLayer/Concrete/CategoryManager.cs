using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DTOLayer.DTOs.CategoryDTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : IGenericService<Category>,ICategoryService
    {
        EfCategoryRepository _categoryRepository;

        public CategoryManager(EfCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Delete(Category t)
        {
            _categoryRepository.Delete(t);
        }

        public ICollection<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void Insert(Category t)
        {
            _categoryRepository.Insert(t);
        }

        public void Edit(Category t)
        {
            _categoryRepository.Edit(t);
        }
        public List<CategoryList> GetCategoryWithProducts()
        {
           return _categoryRepository.GetCategoryWithProducts();
        }

        public Category GetByName(string categoryName)
        {
            return _categoryRepository.GetByName(categoryName);
        }
    }
}
