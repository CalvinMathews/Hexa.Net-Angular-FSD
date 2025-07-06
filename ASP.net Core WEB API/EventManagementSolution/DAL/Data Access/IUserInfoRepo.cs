using DAL.Models;
using System.Collections.Generic;

namespace DAL.DataAccess
{
    public interface IUserInfoRepo<T>
    {
        T GetUserByEmail(string emailId);
        T UpdateUser(T user);
        T AddUser(T user);
        T DeleteUser(string emailId);
        T ValidateUser(string emailId);
        List<T> GetAllUsers();
    }
}
