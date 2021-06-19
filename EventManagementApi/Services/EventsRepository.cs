using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services
{
    public class EventsRepository : IEventsRepository
    {
        private List<Event> Events { get; }  
        public Event Add(Event newEvent)
        {
            Events.Add(newEvent);
            return newEvent;
        }

        public IEnumerable<Event> GetAll() => Events;

        public Event GetById(int id) => Events.FirstOrDefault(e => e.Id == id);
       
        public void Delete(int id)
        {
            var eventTODelete = GetById(id);

            if (eventTODelete == null)
            {
                throw new ArgumentException("No event exists with the given id", nameof(id));
            }
            Events.Remove(eventTODelete);
        }
    }

    public class Event
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }
    }
}
