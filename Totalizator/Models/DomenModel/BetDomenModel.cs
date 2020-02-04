using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Totalizator.Models.DomenModel
{
    public class BetDomenModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int TeamId { get; set; }
        public double Amount { get; set; }

        public string EventName { get; set; }
        public string EventDate { get; set; }
        public string EventStatus { get; set; }
        public string Winner { get; set; }
    }
}