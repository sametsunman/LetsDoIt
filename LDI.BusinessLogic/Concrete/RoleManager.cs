using LDI.BusinessLogic.Abstract;
using LDI.DataAccess.Abstract;
using LDI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDI.BusinessLogic.Concrete
{
    public class RoleManager : IRoleService
    {
        IRoleRepo roleRepo;

        public RoleManager(IRoleRepo _roleRepo)
        {
            roleRepo = _roleRepo;
        }

        public bool Add(Role data)
        {
            return roleRepo.Add(data);
        }

        public ICollection<UserRole> GetListByUser(int userId)
        {

            /// TODO: burası olacak he 
            ///

            throw new NotImplementedException();
        }

        public bool Update(Role data)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserRole(int[] roleId)
        {
            throw new NotImplementedException();
        }
    }
}
