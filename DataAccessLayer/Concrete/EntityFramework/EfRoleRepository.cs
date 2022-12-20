using DataAccessLayer.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfRoleRepository: EfGenericRepository<Role>,IRoleDal
    {
    }
}
