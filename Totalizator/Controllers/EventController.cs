using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Totalizator.Models;
using Totalizator.Models.DbModel;
using Totalizator.Models.DomenModel;
using Totalizator.Models.Enums;
using Totalizator.Services;

namespace Totalizator.Controllers
{
    [Authorize(Roles = "Admin, Moderator")]
    public class EventController : ApiController
    {
        IEventRepository repository;

        public EventController(IEventRepository eventRepository)
        {
            repository = eventRepository;
        }


        [HttpGet]
        public string GetStatusList()
        {
            var listOfStatuses = typeof(EventStatusEnum).GetEnumNames();

            return JsonConvert.SerializeObject(listOfStatuses);
        }

        public string GetTypesList()
        {
            totalizatorEntities dB = new totalizatorEntities();
            var typesList = dB.Types.ToList();
            return JsonConvert.SerializeObject(typesList);
        }

        [HttpPost]
        public HttpResponseMessage Register(EventDomenModel domenEventData)
        {
            if (domenEventData != null) //TODO ADD VALIDATION
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<EventDomenModel, Event>()
                .ForMember(x => x.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date))));


                var mapper = new Mapper(config);
                Event eventData = mapper.Map<EventDomenModel, Event>(domenEventData);
                eventData.CreateDate = DateTime.Now;
                repository.AddEvent(eventData);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

    }
}
