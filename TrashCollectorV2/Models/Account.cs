using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorV2.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public int Balance { get; set; }
        [Display(Name = "Suspended Service?")]
        public bool IsSuspended { get; set; }
        [Display(Name = "Day Of Pickup")]
        public DayOfWeek PickupDay { get; set; }
        [Display(Name = "Next Pickup")]
        public DateTime NextPickup { get; set; }
        [Display(Name = "One Time Pickup")]
        public DateTime OneTimePickup { get; set; }
        [Display(Name = "Start of Suspension Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End of Suspension Date")]
        public DateTime EndDate { get; set; }
    }
}
