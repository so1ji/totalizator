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

        public IEnumerable<Bet> ListBet()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return db.Bets;
        }
    }
}