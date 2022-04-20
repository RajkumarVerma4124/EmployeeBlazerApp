using BusinessLayer.Interface;
using CommonLayer.Models;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    /// <summary>
    /// Created The EmployeeRegister Business Layer Class To Implement IEmployeeRegisterBL Methods
    /// </summary>
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

        /// <summary>
        /// Method To Return Repo Layer AddEmployee Method
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method To Return Repo Layer GetAllEmployee Method
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Method To Return Repo Layer GetEmployee Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method To Return Repo Layer UpdateEmployee Method
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method To Return Repo Layer DeleteEmployee Method
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
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
