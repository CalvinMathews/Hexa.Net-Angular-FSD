using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class SpeakersDetailsRepo : ISpeakersDetailsRepo<SpeakersDetails>
    {
        public SpeakersDetails GetSpeakerDetailsById(int id)
        {
            using var dbContext = new EventContext();
            return dbContext.SpeakersDetails.FirstOrDefault(s => s.SpeakerId == id);
        }

        public SpeakersDetails UpdateSpeakerDetails(SpeakersDetails speaker)
        {
            using var dbContext = new EventContext();
            var existingSpeaker = dbContext.SpeakersDetails.FirstOrDefault(s => s.SpeakerId == speaker.SpeakerId);
            if (existingSpeaker != null)
            {
                existingSpeaker.SpeakerName = speaker.SpeakerName;
                dbContext.SaveChanges();
                return existingSpeaker;
            }
            return null;
        }

        public SpeakersDetails AddSpeakerDetails(SpeakersDetails speaker)
        {
            using var dbContext = new EventContext();
            dbContext.SpeakersDetails.Add(speaker);
            dbContext.SaveChanges();
            return speaker;
        }

        public SpeakersDetails DeleteSpeakerDetails(int id)
        {
            using var dbContext = new EventContext();
            var existingSpeaker = dbContext.SpeakersDetails.FirstOrDefault(s => s.SpeakerId == id);
            if (existingSpeaker != null)
            {
                dbContext.SpeakersDetails.Remove(existingSpeaker);
                dbContext.SaveChanges();
                return existingSpeaker;
            }
            return null;
        }

        public List<SpeakersDetails> GetAllSpeakerDetails()
        {
            using var dbContext = new EventContext();
            return dbContext.SpeakersDetails.ToList();
        }
    }
}
