using System.Collections.Generic;
using DAL.DataAccess;
using DAL.Models;

namespace AppUI
{
    public class EventService
    {
        private readonly IEventRepo _eventRepository;

        public EventService(IEventRepo eventRepository)
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
            _eventRepository.RemoveEvent(eventId);
        }

        public EventDetails GetEventById(int eventId)
        {
            return _eventRepository.GetEventById(eventId);

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