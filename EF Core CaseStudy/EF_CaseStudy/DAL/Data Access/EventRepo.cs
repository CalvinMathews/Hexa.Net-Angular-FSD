using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class EventRepo : IEventRepo<EventDetails>
    {
        public List<EventDetails> GetEventsByCategory(string category)
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.Events
                                .Where(e => e.EventCategory.Equals(category, StringComparison.OrdinalIgnoreCase))
                                .ToList();
            }
        }

        public EventDetails UpdateEvent(EventDetails eventDetails)
        {
            using (var dbContext = new EventDbContext())
            {
                var rowsAffected = dbContext.Database.ExecuteSqlRaw(
                    "EXEC sp_UpdateEvent @EventId = {0}, @EventName = {1}, @EventCategory = {2}, @EventDate = {3}, @Description = {4}, @Status = {5}",
                    eventDetails.EventId,
                    eventDetails.EventName,
                    eventDetails.EventCategory,
                    eventDetails.EventDate,
                    eventDetails.Description,
                    eventDetails.Status
                );

                return rowsAffected > 0 ? eventDetails : null;
            }
        }

        public EventDetails AddEvent(EventDetails eventDetails)
        {
            using (var dbContext = new EventDbContext())
            {
                var rowsAffected = dbContext.Database.ExecuteSqlRaw(
                    "EXEC sp_InsertEvent @EventName = {0}, @EventCategory = {1}, @EventDate = {2}, @Description = {3}, @Status = {4}",
                    eventDetails.EventName,
                    eventDetails.EventCategory,
                    eventDetails.EventDate,
                    eventDetails.Description,
                    eventDetails.Status
                );

                return rowsAffected > 0 ? eventDetails : null;
            }
        }

        public EventDetails DeleteEvent(int eventId)
        {
            using (var dbContext = new EventDbContext())
            {
                var rowsAffected = dbContext.Database.ExecuteSqlRaw(
                    "EXEC sp_DeleteEvent @EventId = {0}",
                    eventId
                );

                return rowsAffected > 0 ? new EventDetails { EventId = eventId } : null;
            }
        }

        public List<EventDetails> GetAllEvents()
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.Events.ToList();
            }
        }
    }
}