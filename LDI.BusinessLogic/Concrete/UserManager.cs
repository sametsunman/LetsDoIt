using LDI.BusinessLogic.Abstract;
using LDI.DataAccess.Abstract;
using LDI.DataAccess.Concrete;
using LDI.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LDI.BusinessLogic.Concrete
{
    public class UserManager : IUserService
    {
        IUserRepo userRepo;

        public UserManager(IUserRepo _userRepo)
        {
            userRepo = _userRepo;
        }

        public bool Add(User data)
        {
           return userRepo.Add(data);

        }

        public bool Delete(int id)
        {
            userRepo.deleteRole(id);

            return userRepo.Delete(id);
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            return userRepo.Get(filter);
        }

        public ICollection<User> GetList(Expression<Func<User, bool>> filter = null)
        {
            return userRepo.GetList(filter);
        }

        public bool Update(User data)
        {
            return userRepo.Update(data);
        }

        public IList<Role> GetRoles(int id)
        {
            return userRepo.GetRoles(id);
        }

        public IList<Channel> GetChannel(int id)
        {
            return userRepo.GetChannels(id);
        }

        public int SetRoles(int roleID, int userID)
        {
            return userRepo.SetRole(roleID, userID);
        }
    }
}
