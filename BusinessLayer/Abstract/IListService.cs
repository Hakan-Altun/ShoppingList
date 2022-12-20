using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IListService: IGenericService<List>
    {
         List GetByName(string listName);
    }
}
