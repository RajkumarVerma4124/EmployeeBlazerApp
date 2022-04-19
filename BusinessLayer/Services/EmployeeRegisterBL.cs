using BusinessLayer.Interface;
using CommonLayer.Models;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmployeeRegisterBL : IEmployeeRegisterBL
    {
        /// <summary>
        /// Reference Object For Interface IEmployeeRegisterRL
        /// </summary>
        private readonly IEmployeeRegisterRL employeeRL;

        /// <summary>
        /// Created Constructor With Dependency Injection For IEmployeeRegisterRL
        /// </summary>
        /// <param name="employeeRL"></param>
        public EmployeeRegisterBL(IEmployeeRegisterRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }

        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            try
            {
                return employeeRL.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            try
            {
                return employeeRL.GetAllEmployee();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmployeeModel GetEmployee(int id)
        {
            try
            {
                return employeeRL.GetEmployee(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                return employeeRL.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteEmployee(int id)
        {
            try
            {
                return employeeRL.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
