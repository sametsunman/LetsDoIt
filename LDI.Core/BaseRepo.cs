using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LDI.Core
{
    public class BaseRepo<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly DbContext context;

        public BaseRepo(DbContext _context)
        {
            context = _context;
        }

        public bool Add(TEntity data )
        {
            try
            {
                var added = context.Entry(data);
                added.State = EntityState.Added;
                context.SaveChanges();

                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var data = context.Find<TEntity>(id);
                var deleted = context.Entry(data);
                deleted.State = EntityState.Deleted;
                context.SaveChanges();

                return  true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Update(TEntity data)
        {

            try
            {
                var modified = context.Entry(data);
                modified.State = EntityState.Modified;
                context.SaveChanges();

                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {

            return context.Set<TEntity>().FirstOrDefault(filter);

        }

        public ICollection<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            if(filter==null)
            return context.Set<TEntity>().ToList();
            else
            { 
            
                var db = context.Set<TEntity>() as IQueryable<TEntity>;


                return db.Where(filter).ToList();
            }
        }


    }
}
