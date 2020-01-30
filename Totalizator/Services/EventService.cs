﻿using System;
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

        public int GetCountOfEvents()
        {
            return db.Events.Count();
        }

        public void UpdateEvent(Event item)
        {
            var oldEvent = db.Events.Where(p => p.Id == item.Id).FirstOrDefault();
            oldEvent = item;
            db.SaveChanges();
                
        }

        public IQueryable<Event> ListEvent(int pageNumber)
        {
            int pageSize = 7;
            db.Configuration.LazyLoadingEnabled = false;
            return db.Events.Include("Team").Include("Team1").Include("Type").OrderByDescending(p => p.Date).Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}