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
    public class UserManager : IGenericService<User>,IUserService
    {
        EfUserRepository _userRepository;

        public UserManager(EfUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Delete(User t)
        {
            _userRepository.Delete(t);  
        }

        public ICollection<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void Insert(User t)
        {
            _userRepository.Insert(t);
        }

        public void Edit(User t)
        {
            _userRepository.Edit(t);
        }

        public User GetUser(string userEmail, string userPassword)
        {
           return _userRepository.GetUser(userEmail, userPassword);
        }

        public User GetByName(string userEmail)
        {
            return _userRepository.GetByName(userEmail);
        }
    }
}
