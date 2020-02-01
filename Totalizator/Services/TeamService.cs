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
        totalizatorEntities db = new totalizatorEntities();
        public void AddTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Team> ListTeam()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return db.Teams;
        }
    }
}