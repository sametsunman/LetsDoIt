using LDI.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LDI.BusinessLogic.Abstract
{
    public interface IUserService
    {
        bool Add(User data);
        bool Delete(int id);
        bool Update(User data);

        ICollection<User> GetList(Expression<Func<User, bool>> filter = null);
        User Get(Expression<Func<User, bool>> filter);

        IList<Channel> GetChannel(int id);
        IList<Role> GetRoles(int id);
        int SetRoles(int roleID, int userID);




    }
}
