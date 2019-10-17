using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LDI.Core
{
    public interface IRepository<TEntity> where TEntity : class, IEntity, new ()
    {
        bool Add(TEntity data);
        bool Update(TEntity data);
        bool Delete(int id);
        ICollection<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter);

    }
}
