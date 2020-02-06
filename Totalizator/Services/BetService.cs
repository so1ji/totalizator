using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Totalizator.Models;
using Totalizator.Models.DbModel;

namespace Totalizator.Services
{
    public class BetService : IBetRepository
    {
        totalizatorEntities db = new totalizatorEntities();

        public void AddBet(Bet item)
        {
            if (item != null)
            {
                db.Bets.Add(item);
                db.SaveChanges();
            };
        }

        public int GetCountOfBets(int userId)
        {
            return db.Bets.Where(x => x.UserId == userId).Count();
        }

        public IEnumerable<Bet> ListBet()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return db.Bets;
        }

        public IQueryable<Bet> ListBet(int pageNumber, int userId)
        {
            db.Configuration.LazyLoadingEnabled = false;
            int pageSize = 3;
            return db.Bets.Include("Event").Include("Team").Where(x => x.UserId == userId).OrderByDescending(p => p.Event.Date).Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}