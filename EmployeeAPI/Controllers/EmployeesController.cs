﻿using EmployeeAPI.Models;
using EmployeeAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(EmployeesController));
        private readonly IEmpRepos _context;
        public EmployeesController(IEmpRepos context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Employees> GetAllEmployees()
        {
            _log4net.Info("Get All Employees is Called !!");
            return _context.GetAllEmployees();
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            _log4net.Info("Get Employee By ID is Called !!");
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = _context.GetEmployeeById(id);
            _log4net.Info("Employee of Id " + id + " is called");
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> PostEmployees(Employees item)
        {
            _log4net.Info("Post Employees is called !!");
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addEmployee = await _context.PostEmployees(item);
            return Ok(addEmployee);
        }
    }
}