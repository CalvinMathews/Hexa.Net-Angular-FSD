using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class ParticipantEventDetailsRepo : IParticipantEventDetailsRepo<ParticipantEventDetails>
    {
        public ParticipantEventDetails GetParticipantEventDetailsById(int id)
        {
            using var dbContext = new EventContext();
            return dbContext.ParticipantEventDetails.FirstOrDefault(p => p.Id == id);
        }

        public ParticipantEventDetails UpdateParticipantEventDetails(ParticipantEventDetails participantEventDetails)
        {
            using var dbContext = new EventContext();
            var existing = dbContext.ParticipantEventDetails.FirstOrDefault(p => p.Id == participantEventDetails.Id);
            if (existing != null)
            {
                existing.ParticipantEmailId = participantEventDetails.ParticipantEmailId;
                existing.EventId = participantEventDetails.EventId;
                existing.IsAttended = participantEventDetails.IsAttended;
                dbContext.SaveChanges();
                return existing;
            }
            return null;
        }

        public ParticipantEventDetails AddParticipantEventDetails(ParticipantEventDetails participantEventDetails)
        {
            using var dbContext = new EventContext();
            dbContext.ParticipantEventDetails.Add(participantEventDetails);
            dbContext.SaveChanges();
            return participantEventDetails;
        }

        public ParticipantEventDetails DeleteParticipantEventDetails(int id)
        {
            using var dbContext = new EventContext();
            var existing = dbContext.ParticipantEventDetails.FirstOrDefault(p => p.Id == id);
            if (existing != null)
            {
                dbContext.ParticipantEventDetails.Remove(existing);
                dbContext.SaveChanges();
                return existing;
            }
            return null;
        }

        public List<ParticipantEventDetails> GetAllParticipantEventDetails()
        {
            using var dbContext = new EventContext();
            return dbContext.ParticipantEventDetails.ToList();
        }
    }
}
