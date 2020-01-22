using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Totalizator.Models;
using Totalizator.Models.DbModel;

namespace Totalizator.Services
{
    public class EventService : IEventRepository
    {
        totalizatorEntities db = new totalizatorEntities();
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