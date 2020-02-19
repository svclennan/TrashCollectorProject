﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollectorV2.Models;

namespace TrashCollectorV2.Contracts
{
    public interface IEmployeeRepository:IRepositoryBase<Employee>
    {
        public void CreateEmployee(Employee employee);
        public Employee GetEmployee(int employeeId);
    }
}
