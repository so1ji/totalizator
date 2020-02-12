using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Totalizator.Models;
using Totalizator.Models.DbModel;

namespace Totalizator.Services
{
    public class TeamService : ITeamRepository
    {

        ITotalizatorContext db;

        public TeamService(ITotalizatorContext dbContext)
        {
            db = dbContext;
        }

        public void AddTeam(Team team)
        {
            if (team != null)
            {
                db.Teams.Add(team);
                db.SaveChanges();
            }
        }

        public IEnumerable<Team> ListTeam()
        {
          //  db.Configuration.LazyLoadingEnabled = false;
            return db.Teams;
        }
    }
}