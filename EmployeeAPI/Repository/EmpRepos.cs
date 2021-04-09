using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Repository
{
    public class EmpRepos : IEmpRepos
    {
        private readonly CommunityGateDatabaseContext _context;

        public EmpRepos()
        {

        }
        public EmpRepos(CommunityGateDatabaseContext context)
        {
            _context = context;
        }
       
        public IEnumerable<Employees> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }
        public Employees GetEmployeeById(int id)
        {
            Employees item = _context.Employees.Find(id);
            return item;
        }

        public async Task<Employees> PostEmployees(Employees item)
        {
            Employees employee = null;
            if(item == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                employee = new Employees() {EmployeeName = item.EmployeeName, EmployeeEmail = item.EmployeeEmail, EmployeeDept = item.EmployeeDept, EmployeeMobile = item.EmployeeMobile, EmployeePassword = item.EmployeePassword, EmployeeRating = item.EmployeeRating, EmployeeWallet = item.EmployeeWallet,IsApproved = item.IsApproved };
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
            }
            return employee;
        }

        public async Task<Employees> RemoveEmployee(int id)
        {
            Employees employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return employee;
        }

        public async Task<Employees> UpdateEmployee(Employees item, int id)
        {
            Employees employee = await _context.Employees.FindAsync(id);
            employee.EmployeeName = item.EmployeeName;
            employee.EmployeeEmail = item.EmployeeEmail;
            employee.EmployeeDept = item.EmployeeDept;
            employee.EmployeeMobile = item.EmployeeMobile;
            employee.EmployeePassword = item.EmployeePassword;
            employee.EmployeeRating = item.EmployeeRating;
            employee.EmployeeWallet = item.EmployeeWallet;
            employee.IsApproved = item.IsApproved;
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<Employees> UpdateEmployeeWallet(int id,int item)
        {
            Employees employee = await _context.Employees.FindAsync(id);
            employee.EmployeeWallet = item;
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employees> UpdateEmployeeRating(int id,int item)
        {
            Employees employee = await _context.Employees.FindAsync(id);
            int newrating = (int)Math.Ceiling((double)((employee.EmployeeRating+item+0.1)/2));
            if(newrating > 5)
            {
                newrating = 5;
            }
            employee.EmployeeRating = newrating;
            await _context.SaveChangesAsync();
            return employee;
        }
    }
}
