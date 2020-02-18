﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorV2.Models
{
    public class Pickups
    {
        [Key]
        public int Id { get; set; }
        public string PickupDay { get; set; }
        public DateTime OneTimePickup { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
