using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Totalizator.Models;

namespace Totalizator.Services
{
    public class TeamService : ITeamRepository
    {
        sweeptakesDBEntities sweeptakes = new sweeptakesDBEntities();
        public void AddTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Team> ListTeam()
        {
            return sweeptakes.Teams;
        }
    }
}