using LDI.Core;
using LDI.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LDI.DataAccess.Abstract
{
    public interface ICategoryRepo : IRepository<Category>
    {
        Task<IList<Category>> GetByParent(int id);
    }
}
