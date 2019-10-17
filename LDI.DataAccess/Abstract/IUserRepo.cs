using LDI.Core;
using LDI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDI.DataAccess.Abstract
{
    public interface IUserRepo : IRepository<User>
    {
        IList<Role> GetRoles(int id);
        IList<Channel> GetChannels(int id);
        int SetRole(int roleID, int userID);
        int deleteRole(int userID);
    }
}
