using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class SessionInfoRepo : ISessionInfoRepo<Session>
    {
        public Session GetSessionInfoById(int id)
        {
            using var dbContext = new EventContext();
            return dbContext.Session.FirstOrDefault(s => s.Id == id);
        }

        public Session UpdateSessionInfo(Session session)
        {
            using var dbContext = new EventContext();
            var existingSession = dbContext.Session.FirstOrDefault(s => s.Id == session.Id);
            if (existingSession != null)
            {
                existingSession.EId = session.EId;
                existingSession.Title = session.Title;
                existingSession.SId = session.SId;
                existingSession.Desc = session.Desc;
                existingSession.Start = session.Start;
                existingSession.End = session.End;
                existingSession.Url = session.Url;
                dbContext.SaveChanges();
                return existingSession;
            }
            return null;
        }

        public Session AddSessionInfo(Session session)
        {
            using var dbContext = new EventContext();
            dbContext.Session.Add(session);
            dbContext.SaveChanges();
            return session;
        }

        public Session DeleteSessionInfo(int id)
        {
            using var dbContext = new EventContext();
            var existingSession = dbContext.Session.FirstOrDefault(s => s.Id == id);
            if (existingSession != null)
            {
                dbContext.Session.Remove(existingSession);
                dbContext.SaveChanges();
                return existingSession;
            }
            return null;
        }

        public List<Session> GetAllSessionInfo()
        {
            using var dbContext = new EventContext();
            return dbContext.Session.ToList();
        }
    }
}
