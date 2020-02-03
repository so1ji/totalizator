using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Totalizator.Models.DbModel;
using Totalizator.Models.DomenModel;
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

        public HttpResponseMessage CreateBet(BetDomenModel newBetDomen)
        {
            if (newBetDomen != null)
            {
                var newBet = Mapper.Map<Bet>(newBetDomen);
                repository.AddBet(newBet);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

    }
}
