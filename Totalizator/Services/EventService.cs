using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Totalizator.Models;

namespace Totalizator.Services
{
    public class EventService : IEventRepository
    {
        sweeptakesDBEntities db = new sweeptakesDBEntities();
        public void AddEvent(Event item)
        {
            if (item != null)
            {
                db.Events.Add(item);
                db.SaveChanges();
            }
        }

        public IEnumerable<Event> ListEvent()
        {
            return db.Events;
        }
    }
}