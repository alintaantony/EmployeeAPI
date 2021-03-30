﻿using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Repository
{
    public interface IEmpRepos
    {
        IEnumerable<Employees> GetAllEmployees();
        Employees GetEmployeeById(int id);
        Task<Employees> PostEmployees(Employees item);
        Task<Employees> RemoveEmployee(int id);
        Task<Employees> UpdateEmployee(Employees item, int id);

    }
}
