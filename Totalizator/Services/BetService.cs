using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Totalizator.Models;
using Totalizator.Models.DbModel;
using Totalizator.Util.Exeptions;

namespace Totalizator.Services
{
    public class BetService : IBetRepository
    {
        ITotalizatorContext db;

        public BetService(ITotalizatorContext dbContext)
        {
            db = dbContext;
        }

        public void AddBet(Bet item)
        {
            if (item != null)
            {
                db.Bets.Add(item);
                db.SaveChanges();
            };
        }

        public void DeleteBet(int betId)
        {
            if (betId <= 0) throw new WrongIdExeption("Id of Bet can't be 0 of lower");
            db.Bets.Remove(db.Bets.Where(p => p.Id == betId).FirstOrDefault());
            db.SaveChanges();
        }

        public int GetCountOfBets(int userId)
        {
            return db.Bets.Where(x => x.UserId == userId).Count();
        }

        public IEnumerable<Bet> ListBet()
        {
            return db.Bets;
        }

        public IQueryable<Bet> ListBet(int pageNumber, int userId)
        {
            if (userId <= 0) throw new WrongIdExeption("User Id can't be 0 or lower");
            if (pageNumber <= 0) throw new WrongPageNumberExeption("Page number can't be 0 or lower");
            int pageSize = 3;
            return db.Bets.Include("Event").Include("Team").Where(x => x.UserId == userId).OrderByDescending(p => p.Event.Date).Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}