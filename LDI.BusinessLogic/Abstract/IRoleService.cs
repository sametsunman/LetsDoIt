using LDI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDI.BusinessLogic.Abstract
{
    public interface IRoleService
    {

        bool Add(Role data);
        bool Update(Role data);
        ICollection<UserRole> GetListByUser(int userId);
        bool UpdateUserRole(int[] roleId);

    }
}
