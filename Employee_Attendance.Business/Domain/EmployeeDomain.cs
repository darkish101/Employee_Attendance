using Arch.EntityFrameworkCore.UnitOfWork;
using Employee_Attendance.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Employee_Attendance.Business
{
   public class EmployeeDomain //: BaseDomain<Employee, EmployeeRepository>
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly UserManager<Employee> _userManager;

        public EmployeeDomain(EmployeeRepository repository, IUnitOfWork unitOfWork, UserManager<Employee> userManager)//: base(repository, unitOfWork)
        {
            _employeeRepository = repository;
            _iUnitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task InsertEmployee(EmployeeViewModel viewModel)
        {
                var employee = new Employee();
                employee.Employee_Name = viewModel.Employee_Name;
                employee.Employment_Id= viewModel.Employment_Id;
                employee.Email = viewModel.Email;
                employee.UserName = viewModel.UserName;
                employee.PasswordHash = viewModel.Passowrd;
                employee.Added_By = viewModel.Added_By;

                await   _userManager.CreateAsync(employee);


                //await _employeeRepository.InsertAsync(employee);
                //await _iUnitOfWork.SaveChangesAsync();
        }
        public async Task UpdateEmployee(EmployeeViewModel viewModel)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeById(Convert.ToInt32(viewModel.Id));
                employee.Employee_Name = viewModel.Employee_Name;
                employee.Employment_Id = viewModel.Employment_Id;
                await _iUnitOfWork.SaveChangesAsync(); // base.UpdateAsync(employee);
            }
            catch
            {
                throw;
            }
        }
        public async Task DeleteEmployee(int Id)
        {
            try
            {
                await _employeeRepository.DeleteAsync(Id); // base.DeleteAsync(Id);
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<EmployeeViewModel>> GetAllEmployee()
        {
            try
            {
                var categories = await _employeeRepository.GetAllEmployee();
                return categories.Select(x => new EmployeeViewModel
                {
                    Id = x.Id,
                    Employee_Name = x.Employee_Name,
                    UserName = x.UserName,
                    Employment_Id = x.Employment_Id,
                }).ToList();
            }
            catch
            {
                throw;
            }
        }
        public async Task<EmployeeViewModel> EmployeeById(string Id)
        {
            try
            {
                var Data = await _employeeRepository.GetAllEmployee();
                var employee = Data.First(x => x.Id == Id);
                return new EmployeeViewModel
                {
                    Id = employee.Id,
                    Employee_Name = employee.Employee_Name,
                    Employment_Id = employee.Employment_Id,
                };
            }
            catch
            {
                throw;
            }
        }
    }
}
