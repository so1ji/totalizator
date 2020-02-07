using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
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

        [HttpGet]
        public string GetBetList(int pageNumber, int userId)
        {
            var betList = repository.ListBet(pageNumber, userId);
            List<BetDomenModel> betListDomen = new List<BetDomenModel>();
            foreach (Bet e in betList)
            {
                BetDomenModel eventItemDomen = Mapper.Map<BetDomenModel>(e);
                betListDomen.Add(eventItemDomen);
            }
            return JsonConvert.SerializeObject(betListDomen);
        }

        [HttpPost]
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

        [HttpGet]
        public string GetCountOfBets(int userId)
        {
            var countOfBets = repository.GetCountOfBets(userId);
            return JsonConvert.SerializeObject(countOfBets);
        }

        [HttpGet]
        public HttpResponseMessage DeleteBetById(int betId)
        {
            repository.DeleteBet(betId);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
