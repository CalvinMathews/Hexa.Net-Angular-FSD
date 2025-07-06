using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface IParticipantEventDetailsRepo<T>
    {
        T GetParticipantEventDetailsById(int participantId);
        T UpdateParticipantEventDetails(T participantEventDetails);
        T AddParticipantEventDetails(T participantEventDetails);
        T DeleteParticipantEventDetails(int participantId);
        List<T> GetAllParticipantEventDetails();
    }
}
