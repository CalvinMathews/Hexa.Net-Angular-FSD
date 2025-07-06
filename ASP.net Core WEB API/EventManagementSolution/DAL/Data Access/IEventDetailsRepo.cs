using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface IEventDetailsRepo<T>
    {
        T GetEventsById(int eventId);
        T UpdateEvent(T eventDetails);
        T AddEvent(T eventDetails);
        T DeleteEvent(int eventId);
        List<T> GetAllEvents();

    }
}
