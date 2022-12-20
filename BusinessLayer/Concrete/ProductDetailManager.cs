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
    public class ProductDetailManager : IGenericService<ProductDetail>
    {
        EfProductDetailRepository _detailRepository;

        public ProductDetailManager(EfProductDetailRepository detailRepository)
        {
            _detailRepository = detailRepository;
        }

        public void Delete(ProductDetail t)
        {
            _detailRepository.Delete(t);
        }

        public ICollection<ProductDetail> GetAll()
        {
            return _detailRepository.GetAll();
        }

        public ProductDetail GetById(int id)
        {
            return _detailRepository.GetById(id);
        }

        public void Insert(ProductDetail t)
        {
            _detailRepository.Insert(t);
        }

        public void Edit(ProductDetail t)
        {
            _detailRepository.Edit(t);
        }

        public ProductDetail GetByName(string productDetailName)
        {
            return _detailRepository.GetByName(productDetailName);
        }
    }
}
