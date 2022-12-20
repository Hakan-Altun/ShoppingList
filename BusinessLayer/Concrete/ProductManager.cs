using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager:IGenericService<Product>,IProductService
    {
        EfProductRepository _productRepository;
        public ProductManager(EfProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Delete(Product t)
        {
            _productRepository.Delete(t);
        }

        public ICollection<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);  
        }

        public void Insert(Product t)
        {
            _productRepository.Insert(t);
        }

        public void Edit(Product t)
        {
            _productRepository.Edit(t);
        }

        public Product GetByName(string productName)
        {
            return _productRepository.GetByName(productName);
        }

        public List<Product> GetProductWithList()
        {
            return _productRepository.GetProductWithList();
        }
    }
}
