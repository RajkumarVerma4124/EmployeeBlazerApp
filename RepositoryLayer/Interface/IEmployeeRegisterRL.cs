using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    /// <summary>
    /// Created The Interface For EmployeeRegister Repository Layer Class
    /// </summary>
    public interface IEmployeeRegisterRL
    {
        public EmployeeModel AddEmployee(EmployeeModel employee);
        public IEnumerable<EmployeeModel> GetAllEmployee();
        public EmployeeModel GetEmployee(int id);
        public string UpdateEmployee(EmployeeModel employee);
        public string DeleteEmployee(int id);
    }
}
