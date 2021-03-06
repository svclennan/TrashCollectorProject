﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollectorV2.Contracts;
using TrashCollectorV2.Models;

namespace TrashCollectorV2.Data
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
        public void CreateAddress(Address address)
        {
            Create(address);
        }
        public Address GetAddress(int addressId)
        {
            return FindByCondition(a => a.Id == addressId).SingleOrDefault();
        }
    }
}
