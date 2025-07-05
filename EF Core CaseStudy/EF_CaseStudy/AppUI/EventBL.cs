using System.Collections.Generic;
using DAL.DataAccess;
using DAL.Models;

namespace AppUI
{
    public class EventBL
    {
        private readonly IEventRepo<EventDetails> _eventRepository;

        public EventBL(IEventRepo<EventDetails> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void AddEvent(EventDetails eventDetails)
        {
            _eventRepository.AddEvent(eventDetails);
        }

        public void UpdateEvent(EventDetails eventDetails)
        {
            _eventRepository.UpdateEvent(eventDetails);
        }

        public void DeleteEvent(int eventId)
        {
            _eventRepository.DeleteEvent(eventId);
        }

        public List<EventDetails> GetEventByCategory(string category)

        {
            return _eventRepository.GetEventsByCategory(category);

        }

        public List<EventDetails> GetAllEvents()
        {
            return _eventRepository.GetAllEvents();
        }

        public List<SessionInfo> GetSessionsByEventId(int eventId)
        {
            return _eventRepository.GetSessionsByEventId(eventId);
        }
    }
}