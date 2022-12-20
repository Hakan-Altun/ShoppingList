using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfUserRepository : EfGenericRepository<User>, IUserDal
    {
        ShoppingListContext context = new();
        public User GetUser(string userEmail,string userPassword)
        {
            User user = context.Users.Include(a => a.Role)
                .Where(a => EF.Functions.Collate(a.UserEmail, "SQL_Latin1_General_CP1_CS_AS") == userEmail && EF.Functions.Collate(a.UserPassword, "SQL_Latin1_General_CP1_CS_AS") == userPassword).SingleOrDefault();
            return user;
        }
        public User GetByName(string name)
        {
            return context.Users.SingleOrDefault(a => a.UserEmail == name);
        }
    }
}
