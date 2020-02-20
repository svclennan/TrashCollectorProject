using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorV2.Contracts
{
    public interface IRepositoryWrapper
    {
        IAccountRepository Account { get; }
        IAddressRepository Address { get; }
        ICustomerRepository Customer { get; }
        IEmployeeRepository Employee { get; }
        void Save();

    }
}
