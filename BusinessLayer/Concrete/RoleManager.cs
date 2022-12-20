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
    public class RoleManager : IGenericService<Role>
    {
        EfRoleRepository _roleRepository;
        public RoleManager(EfRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public void Delete(Role t)
        {
            _roleRepository.Delete(t);
        }

        public ICollection<Role> GetAll()
        {
            return _roleRepository.GetAll();
        }

        public Role GetById(int id)
        {
            return _roleRepository.GetById(id);
        }

        public void Insert(Role t)
        {
            _roleRepository.Insert(t);
        }

        public void Edit(Role t)
        {
            _roleRepository.Edit(t);
        }
    }
}
