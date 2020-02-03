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
        public double Amount { get; set; }
    }
}