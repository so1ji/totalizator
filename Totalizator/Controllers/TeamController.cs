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

        ITeamRepository _repo;

        public TeamController(ITeamRepository teamRepository)
        {
            _repo = teamRepository;
        }

        [HttpGet]
        public HttpResponseMessage GetListOfTeams()
        {
            //var response = Request.CreateResponse<IEnumerable<Team>>(HttpStatusCode.OK, _repo.ListTeam);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
