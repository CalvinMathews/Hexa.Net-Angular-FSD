using DAL.Models;
using System.Collections.Generic;

namespace DAL.DataAccess
{
    public interface ISessionInfoRepo<T>
    {
        T GetSessionInfoById(int id);
        T UpdateSessionInfo(T session);
        T AddSessionInfo(T session);
        T DeleteSessionInfo(int id);
        List<T> GetAllSessionInfo();
    }
}
