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
    public class ListManager : IGenericService<List>
    {
        EfListRepository _listRepository;

        public ListManager(EfListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public void Delete(List t)
        {
            _listRepository.Delete(t);
        }

        public ICollection<List> GetAll()
        {
           return _listRepository.GetAll();
        }

        public List GetById(int id)
        {
            return _listRepository.GetById(id);
        }

        public void Insert(List t)
        {
            _listRepository.Insert(t);
        }

        public void Edit(List t)
        {
            _listRepository.Edit(t);
        }

        public List GetByName(string listName)
        {
            return _listRepository.GetByName(listName);
        }
    }
}
