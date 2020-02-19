using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollectorV2.Models;

namespace TrashCollectorV2.Contracts
{
    public interface IPickupRepository : IRepositoryBase<Pickup>
    {
        public void CreatePickup(Pickup pickup);
        public Pickup GetPickup(int pickupId);
    }
}
