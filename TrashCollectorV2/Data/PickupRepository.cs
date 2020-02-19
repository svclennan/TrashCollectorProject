﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollectorV2.Contracts;
using TrashCollectorV2.Models;

namespace TrashCollectorV2.Data
{
    public class PickupRepository : RepositoryBase<Pickup>, IPickupRepository
    {
        public PickupRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
        public void CreatePickup(Pickup pickup)
        {
            Create(pickup);
        }
        public Pickup GetPickup(int pickupId)
        {
            return FindByCondition(a => a.Id == pickupId).SingleOrDefault();
        }
    }
}
