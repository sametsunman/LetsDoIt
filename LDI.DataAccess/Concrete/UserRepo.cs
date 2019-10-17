using LDI.Core;
using LDI.DataAccess.Abstract;
using LDI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LDI.DataAccess.Concrete
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(Context context) : base(context)
        {

        }



        public IList<Channel> GetChannels(int userID)
        {

            var userChannel = context.Set<UserChannel>() as IQueryable<UserChannel>;
            var channelsOfUser = userChannel.Where(x => x.UserID == userID).ToList();
            IList<Channel> channels = new List<Channel>();
            channelsOfUser.ForEach(x => channels.Add(x.Channel));
            return channels;

        }

        public IList<Role> GetRoles(int userID)
        {

            var userRole = context.Set<UserRole>() as IQueryable<UserRole>;
            var rolesOfUser = userRole.Where(x => x.UserID == userID).ToList();
            IList<Role> roles = new List<Role>();
            var role = context.Set<Role>() as IQueryable<Role>;
            rolesOfUser.ForEach(x => roles.Add(role.Where(y => y.ID == x.RoleID ).SingleOrDefault()));
            return roles;

        }

        public int SetRole(int roleID, int userID)
        {
            UserRole userRole = new UserRole();

            userRole.RoleID = roleID;
            userRole.UserID = userID;

            var added = context.Entry(userRole);
            added.State = EntityState.Added;
            int result = context.SaveChanges();

            return result;
        }

        public int deleteRole(int userID)
        {
            IQueryable<UserRole> userRole = context.Set<UserRole>();
            var rolesOfUser = userRole.Where(x => x.UserID == userID).ToList();

            if(!(rolesOfUser is null))
            {
                foreach (var item in rolesOfUser)
                { 
                    var deleted = context.Entry(item);
                    deleted.State = EntityState.Deleted;
                }
            }
            int result = context.SaveChanges();

            return result;
        }
    }
}
