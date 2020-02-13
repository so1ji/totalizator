using AutoMapper;
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
        ITotalizatorContext db;

        public EventService(ITotalizatorContext dbContext)
        {
            db = dbContext;
        }


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

            oldEvent.TeamFirstCoefficient = item.TeamFirstCoefficient;
            oldEvent.TeamFirstPoints = item.TeamFirstPoints;
            oldEvent.TeamSecondCoefficient = item.TeamSecondCoefficient;
            oldEvent.TeamSecondPoints = item.TeamSecondPoints;
            oldEvent.WinnerId = item.WinnerId;
            oldEvent.EditDate = item.EditDate;
            oldEvent.EditorId = item.EditorId;
            oldEvent.Status = item.Status;

            db.SaveChanges();
        }

        public IQueryable<Event> ListEvent(int pageNumber)
        {
            int pageSize = 7;
            return db.Events.Include("Team").Include("Team1").Include("Type").OrderByDescending(p => p.Date).Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}