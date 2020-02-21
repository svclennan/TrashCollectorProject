using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrashCollectorV2.Contracts;
using TrashCollectorV2.Models;

namespace TrashCollectorV2.Data
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }

        public Customer GetCustomer(int customerId)
        {
            return FindByCondition(a => a.Id == customerId).SingleOrDefault();
        }
        public Customer GetCustomerIncludeAll(int customerId)
        {
            return FindByCondition(a => a.Id.Equals(customerId)).Include(b=>b.Address).SingleOrDefault();
        }

        public List<Customer> GetCustomerIncludeAll() => FindAll().Include(a=> a.Account).Include(b=> b.Address).ToList();

    }
}
