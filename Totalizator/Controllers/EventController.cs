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

        [HttpGet]
        public string GetTypesList()
        {
            totalizatorEntities dB = new totalizatorEntities();
            var typesList = dB.Types.ToList();
            return JsonConvert.SerializeObject(typesList);
        }

        [HttpGet]
        public string GetCountOfEvents()
        {
            var countOfEvents = repository.GetCountOfEvents();
            return JsonConvert.SerializeObject(countOfEvents);
        }

        [HttpGet]
        public string GetEventsList(int pageNumber)
        {
            var eventsList = repository.ListEvent(pageNumber);
            return JsonConvert.SerializeObject(eventsList);
        }

        [HttpPost]
        public HttpResponseMessage Register(EventDomenModel domenEventData)
        {
            if (domenEventData != null) //TODO ADD VALIDATION
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<EventDomenModel, Event>()
                .ForMember(x => x.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date)))
                .ForMember(x => x.Status, opt => opt.MapFrom(src => (byte)(EventStatusEnum)Enum.Parse(typeof(EventStatusEnum), src.Status)))
                );


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
