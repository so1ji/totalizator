using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Totalizator.Models.Enums;

namespace Totalizator.Models.DomenModel
{
    public class EventDomenModel
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeamFirstId { get; set; }
        public int TeamSecondId { get; set; }
        public double TeamFirstCoefficient { get; set; }
        public double TeamSecondCoefficient { get; set; }
        public double TeamFirstPoints { get; set; }
        public double TeamSecondPoints { get; set; }
        public int? WinnerId { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreateDate { get; set; }
        public int? EditorId { get; set; }
        public int? EditDate { get; set; }
        public string Status { get; set; }

        public string TeamFirstName { get; set; }
        public string TeamSecondName { get; set; }
        public string TypeName { get; set; }
    }
}