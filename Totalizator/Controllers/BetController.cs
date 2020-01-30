using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Totalizator.Models.DbModel;
using Totalizator.Services;

namespace Totalizator.Controllers
{
    public class BetController : ApiController
    {

        IBetRepository repository;

        public BetController(IBetRepository betRepository)
        {
            repository = betRepository;
        }

        public HttpResponseMessage CreateBet(Bet newBet)
        {
            if (newBet != null)
            {
                repository.AddBet(newBet);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

    }
}
