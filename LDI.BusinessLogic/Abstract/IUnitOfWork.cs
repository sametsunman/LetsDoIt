using System;
using System.Collections.Generic;
using System.Text;

namespace LDI.BusinessLogic.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryService Category { get; }

        IChannelService Channel { get; }

        IContentService Content { get; }

        IMediaService Media { get; }

        IRoleService Role { get; }

        IUserService User { get; }

        bool SaveChanges();


    }
}
