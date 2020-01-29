    //------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Totalizator.Models.DbModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            this.Bets = new HashSet<Bet>();
        }
    
        public int Id { get; set; }
        public int TypeId { get; set; }
        public System.DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeamFirstId { get; set; }
        public int TeamSecondId { get; set; }
        public double TeamFirstCoefficient { get; set; }
        public double TeamSecondCoefficient { get; set; }
        public Nullable<int> WinnerId { get; set; }
        public double TeamFirstPoints { get; set; }
        public double TeamSecondPoints { get; set; }
        public int CreatorId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<int> EditorId { get; set; }
        public Nullable<int> EditDate { get; set; }
        public byte Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bet> Bets { get; set; }
        public virtual Team Team { get; set; }
        public virtual Team Team1 { get; set; }
        public virtual Team Team2 { get; set; }
        public virtual Type Type { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
