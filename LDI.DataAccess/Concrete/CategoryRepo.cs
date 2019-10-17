using LDI.Core;
using LDI.DataAccess.Abstract;
using LDI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDI.DataAccess.Concrete
{
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(Context context) : base(context)
        { }

        public async Task<IList<Category>> GetByParent(int id)
        {
            var db = context.Set<Category>() as IQueryable<Category>;

            return await db.Where(x => x.ParentID == id).ToListAsync();
        }
    }
}
