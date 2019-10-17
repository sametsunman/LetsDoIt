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
    public class ContentRepo : BaseRepo<Content>, IContentRepo
    {
        public ContentRepo(Context context):base(context)
        {

        }

        public async Task<IList<Content>> GetByChannel(int ChannelID)
        {
            var db = context.Set<Content>() as IQueryable<Content>;

            return await db.Where(x => x.ChannelID == ChannelID).ToListAsync();
        }

        public async Task<IList<Content>> GetByCategory(int categoryID)
        {
            var db = context.Set<Content>() as IQueryable<Content>;

            return await db.Where(x => x.CategoryID == categoryID).ToListAsync();
        }


    }
}
