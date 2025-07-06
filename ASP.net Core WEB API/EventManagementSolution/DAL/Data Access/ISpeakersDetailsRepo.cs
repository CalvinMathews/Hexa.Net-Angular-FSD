using DAL.Models;
using System.Collections.Generic;

namespace DAL.DataAccess
{
    public interface ISpeakersDetailsRepo<T>
    {
        T GetSpeakerDetailsById(int id);
        T UpdateSpeakerDetails(T speaker);
        T AddSpeakerDetails(T speaker);
        T DeleteSpeakerDetails(int id);
        List<T> GetAllSpeakerDetails();
    }
}
