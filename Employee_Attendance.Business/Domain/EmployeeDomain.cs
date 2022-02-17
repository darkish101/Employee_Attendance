using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
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
        #region ctor
        private readonly EmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly IMapper _mapper;
        public EmployeeDomain(EmployeeRepository repository
            , IUnitOfWork unitOfWork
            , UserManager<Employee> userManager
            , SignInManager<Employee> signInManager
            , IMapper mapper)
        {
            _employeeRepository = repository;
            _iUnitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        #endregion
        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
           return await _signInManager.PasswordSignInAsync(model.UserName, model.Passowrd, true, lockoutOnFailure: false);
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<IdentityResult> RegisterAsync(EmployeeViewModel model)
        {
            var user = _mapper.Map<Employee>(model);

            user.Id = Guid.NewGuid().ToString();

            var result = await _userManager.CreateAsync(user, model.Passowrd);
            
            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, "Employee");

            return result;
        }
        public async Task <IdentityResult> InsertEmployee(EmployeeViewModel viewModel)
        {
            //var employee = new Employee();
            //employee.Employee_Name = viewModel.Employee_Name;
            //employee.Employment_Id = viewModel.Employment_Id;
            //employee.Email = viewModel.Email;
            //employee.UserName = viewModel.UserName;
            //employee.Added_By = viewModel.Added_By;

            //var result = await _userManager.CreateAsync(employee, viewModel.Passowrd);
           

            var result = await _userManager.CreateAsync(_mapper.Map<Employee>(viewModel), viewModel.Passowrd);

            return result;
        }
        public async Task UpdateEmployee(EmployeeViewModel viewModel)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeById(viewModel.Id);
                employee.Employee_Name = viewModel.Employee_Name;
                employee.Employment_Id = viewModel.Employment_Id;
                employee.Email = viewModel.Email;
                employee.UserName = viewModel.UserName;
                employee.Id = viewModel.Id;

                await _userManager.UpdateAsync(employee);
                //await _iUnitOfWork.SaveChangesAsync(); // base.UpdateAsync(employee);
            }
            catch
            {
                throw;
            }
        }
        public async Task DeleteEmployee(string Id)
        {
            try
            {
                var result = await _userManager.DeleteAsync(await _employeeRepository.GetEmployeeById(Id));
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
                var empList = await _employeeRepository.GetAllEmployee();
                return empList.Select(x => new EmployeeViewModel
                {
                    Employee_Name = x.Employee_Name,
                    Employment_Id = x.Employment_Id,
                    Email = x.Email,
                    UserName = x.UserName,
                    Added_By = x.Added_By,
                    Id = x.Id
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
                    Employee_Name = employee.Employee_Name,
                    Employment_Id = employee.Employment_Id,
                    Email = employee.Email,
                    UserName = employee.UserName,
                    Added_By = employee.Added_By,
                    Id = employee.Id
                };
            }
            catch
            {
                throw;
            }
        }
    }
}
