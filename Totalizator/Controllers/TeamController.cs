using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Totalizator.Models;
using Totalizator.Services;

namespace Totalizator.Controllers
{
    public class TeamController : ApiController
    {
        ITeamRepository repository;

        public TeamController(ITeamRepository teamRepository)
        {
            repository = teamRepository;
        }

        [HttpGet]
        public string  GetListOfTeams()
        {
            var teamList = repository.ListTeam();
            return JsonConvert.SerializeObject(teamList);
        }
    }
}
