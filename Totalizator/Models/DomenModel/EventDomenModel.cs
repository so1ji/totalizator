using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Totalizator.Models.DomenModel
{
    public class EventDomenModel
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Coefficient { get; set; }
        public int TeamFirstId { get; set; }
        public int TeamSecondId { get; set; }
        public int? WinnerId { get; set; }
        public double TotalPoints { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreateDate { get; set; }
        public int? EditorId { get; set; }
        public int? EditDate { get; set; }
        public byte Status { get; set; }
    }
}