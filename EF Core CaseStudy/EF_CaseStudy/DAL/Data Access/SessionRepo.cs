using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class SessionRepo : ISessionRepo<SessionInfo>
    {
        public SessionInfo GetSessionById(int sessionId)
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.Sessions
                                .FirstOrDefault(s => s.SessionId == sessionId);
            }
        }

        public SessionInfo UpdateSession(SessionInfo sessionInfo)
        {
            using (var dbContext = new EventDbContext())
            {
                var existingSession = dbContext.Sessions
                                               .FirstOrDefault(s => s.SessionId == sessionInfo.SessionId);

                if (existingSession != null)
                {
                    existingSession.SessionTitle = sessionInfo.SessionTitle;
                    existingSession.Description = sessionInfo.Description;
                    existingSession.EventId = sessionInfo.EventId;

                    dbContext.SaveChanges();
                    return existingSession;
                }

                return null;
            }
        }

        public SessionInfo AddSession(SessionInfo sessionInfo)
        {
            using (var dbContext = new EventDbContext())
            {
                dbContext.Sessions.Add(sessionInfo);
                dbContext.SaveChanges();
                return sessionInfo;
            }
        }

        public SessionInfo DeleteSession(int sessionId)
        {
            using (var dbContext = new EventDbContext())
            {
                var sessionToDelete = dbContext.Sessions
                                               .FirstOrDefault(s => s.SessionId == sessionId);

                if (sessionToDelete != null)
                {
                    dbContext.Sessions.Remove(sessionToDelete);
                    dbContext.SaveChanges();
                    return sessionToDelete;
                }

                return null;
            }
        }

        public List<SessionInfo> GetAllSessions()
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.Sessions.ToList();
            }
        }
    }
}