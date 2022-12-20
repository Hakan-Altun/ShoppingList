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
    public class ListProductManager
    {
        EfListProductRepository _listproductRepository;

        public ListProductManager(EfListProductRepository listproductRepository)
        {
            _listproductRepository = listproductRepository;
        }

        public void Delete(ListProduct t)
        {
            _listproductRepository.Delete(t);
        }

        public ICollection<ListProduct> GetAll()
        {
            return _listproductRepository.GetAll();
        }

        public ListProduct GetById(int id)
        {
            return _listproductRepository.GetById(id);
        }

        public void Insert(ListProduct t)
        {
            _listproductRepository.Insert(t);
        }

        public void Edit(ListProduct t)
        {
            _listproductRepository.Edit(t);
        }
    }
}
