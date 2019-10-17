using LDI.BusinessLogic.Abstract;
using LDI.DataAccess;
using LDI.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDI.BusinessLogic.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly Context context;

        public UnitOfWork(Context _context)
        {
            context = _context;
        }


        private ICategoryService category;
        private IChannelService channel;
        private IContentService content;
        private IMediaService media;
        private IRoleService role;
        private IUserService user;


        public ICategoryService Category => category ?? (category = new CategoryManager(new CategoryRepo(context)));
        public IChannelService Channel => channel ?? (channel = new ChannelManager(new ChannelRepo(context)));
        public IContentService Content => content ?? (content = new ContentManager(new ContentRepo(context)));
        public IMediaService Media => media ?? (media = new MediaManager(new MediaRepo(context)));
        public IRoleService Role => role ?? (role = new RoleManager(new RoleRepo(context)));
        public IUserService User => user ?? (user = new UserManager(new UserRepo(context)));


        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }
                disposedValue = true;

            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public bool SaveChanges()
        {
            int result = context.SaveChanges();
            return result > 0 ? true : false;
        }
    }
}
