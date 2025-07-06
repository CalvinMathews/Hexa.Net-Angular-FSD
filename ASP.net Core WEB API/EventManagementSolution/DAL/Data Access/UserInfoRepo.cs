using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class UserInfoRepo : IUserInfoRepo<UserInfo>
    {
        public UserInfo GetUserByEmail(string emailId)
        {
            using var dbContext = new EventContext();
            return dbContext.UserInfo.FirstOrDefault(u => u.EmailId == emailId);
        }

        public UserInfo UpdateUser(UserInfo user)
        {
            using var dbContext = new EventContext();
            var existingUser = dbContext.UserInfo.FirstOrDefault(u => u.EmailId == user.EmailId);
            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                existingUser.Role = user.Role;
                dbContext.SaveChanges();
                return existingUser;
            }
            return null;
        }

        public UserInfo AddUser(UserInfo user)
        {
            using var dbContext = new EventContext();
            dbContext.UserInfo.Add(user);
            dbContext.SaveChanges();
            return user;
        }

        public UserInfo DeleteUser(string emailId)
        {
            using var dbContext = new EventContext();
            var existingUser = dbContext.UserInfo.FirstOrDefault(u => u.EmailId == emailId);
            if (existingUser != null)
            {
                dbContext.UserInfo.Remove(existingUser);
                dbContext.SaveChanges();
                return existingUser;
            }
            return null;
        }

        public UserInfo ValidateUser(string emailId)
        {
            using var dbContext = new EventContext();
            return dbContext.UserInfo.FirstOrDefault(u => u.EmailId == emailId);
        }

        public List<UserInfo> GetAllUsers()
        {
            using var dbContext = new EventContext();
            return dbContext.UserInfo.ToList();
        }
    }
}
