﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollectorV2.Models;

namespace TrashCollectorV2.Contracts
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        public void CreateAccount(Account account);
        public Account GetAccount(int accountId);
    }

}
