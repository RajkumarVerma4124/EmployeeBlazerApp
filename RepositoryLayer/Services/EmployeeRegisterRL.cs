using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;

namespace RepositoryLayer.Services
{
    /// <summary>
    /// Created The Class For EmployeeRegister Repository Layer
    /// </summary>
    public class EmployeeRegisterRL : IEmployeeRegisterRL
    {
        /// <summary>
        /// Reference object for mysqlconnection and Iconfiguartion
        /// </summary>
        private MySqlConnection sqlConnection;
        private readonly IConfiguration configuration;
        public EmployeeRegisterRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            try
            {
                using (sqlConnection = new MySqlConnection(configuration["ConnectionString:EmployeePayrollDB"]))
                {
                    MySqlCommand command = new MySqlCommand("sp_AddEmployee", sqlConnection);
                    //Setting command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    //Add parameters to stored procedures
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@ProfileImg", employee.ProfileImg);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    command.Parameters.AddWithValue("@Notes", employee.Notes);
                    sqlConnection.Open();
                    int result = command.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (result != 0)
                        return null;
                    else
                        return employee;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public EmployeeModel GetEmployee(int id)
        {
            try
            {
                EmployeeModel employeeData = null;
                using (sqlConnection = new MySqlConnection(configuration["ConnectionString:EmployeePayrollDB"]))
                {
                    EmployeeModel employee = new EmployeeModel();
                    employee.Id = id;
                    MySqlCommand command = new MySqlCommand("sp_GetEmployee", sqlConnection);
                    //Setting command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    //Add parameters to stored procedures
                    command.Parameters.AddWithValue("@Id", employee.Id);
                    //Open Sql Connection
                    sqlConnection.Open();
                    //Returns object of result set
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        //Will Loop until rows are null
                        while (reader.Read())
                        {
                            employeeData = PrintEmployeeDetails(reader, employee);
                        }
                        return employeeData;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private EmployeeModel PrintEmployeeDetails(MySqlDataReader reader, EmployeeModel employee)
        {
            employee.Id = Convert.ToInt32(reader["EmployeeId"] == DBNull.Value ? default : reader["EmployeeId"]);
            employee.ProfileImg = reader["ProfileImg"] == DBNull.Value ? default : reader["ProfileImg"].ToString();
            employee.Name = reader["Name"] == DBNull.Value ? default : reader["Name"].ToString();
            employee.Gender = reader["Gender"] == DBNull.Value ? default : reader["Gender"].ToString();
            employee.Department = reader["Department"] == DBNull.Value ? default : reader["Department"].ToString();
            employee.StartDate = Convert.ToDateTime(reader["StartDate"] == DBNull.Value ? default : reader["StartDate"]);
            employee.Date = employee.StartDate.ToString("yyyy-MM-dd");
            employee.Salary = reader["Salary"] == DBNull.Value ? default : reader["Salary"].ToString();
            employee.Notes = reader["Notes"] == DBNull.Value ? default : reader["Notes"].ToString();
            return employee;
        }

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeData = null;
                IList<EmployeeModel> employeeList = new List<EmployeeModel>();
                using (sqlConnection = new MySqlConnection(configuration["ConnectionString:EmployeePayrollDB"]))
                {
                    MySqlCommand command = new MySqlCommand("sp_GetAllEmployee", sqlConnection);
                    //Setting command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    //Open Sql Connection
                    sqlConnection.Open();
                    //Returns object of result set
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        //Will Loop until rows are null
                        while (reader.Read())
                        {
                            EmployeeModel employee = new EmployeeModel();
                            employeeData = PrintEmployeeDetails(reader, employee);
                            employeeList.Add(employeeData);
                        }
                        return employeeList;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        /// <summary>
        /// Method to update employee details of the db table
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public string UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                using (sqlConnection = new MySqlConnection(configuration["ConnectionString:EmployeePayrollDB"]))
                {
                    MySqlCommand command = new MySqlCommand("sp_UpdateEmployee", sqlConnection);
                    //Setting command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    //Add parameters to stored procedures
                    command.Parameters.AddWithValue("@Id", employee.Id);
                    command.Parameters.AddWithValue("@EmpName", employee.Name);
                    command.Parameters.AddWithValue("@EmpProfileImg", employee.ProfileImg);
                    command.Parameters.AddWithValue("@EmpGender", employee.Gender);
                    command.Parameters.AddWithValue("@EmpDepartment", employee.Department);
                    command.Parameters.AddWithValue("@EmpSalary", employee.Salary);
                    command.Parameters.AddWithValue("@EmpStartDate", employee.StartDate);
                    command.Parameters.AddWithValue("@EmpNotes", employee.Notes);
                    sqlConnection.Open();
                    int result = command.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (result != 0)
                        return "Data Updated Succesfully";
                    else
                        return "Update Unsuccessfull";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public string DeleteEmployee(int id)
        {
            try
            {
                using (sqlConnection = new MySqlConnection(configuration["ConnectionString:EmployeePayrollDB"]))
                {
                    MySqlCommand command = new MySqlCommand("sp_DeleteEmployee", sqlConnection);
                    //Setting command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    //Add parameters to stored procedures
                    command.Parameters.AddWithValue("@Id", id);
                    //Open Sql Connection
                    sqlConnection.Open();
                    int result = command.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (result != 0)
                        return "Deleted Data Successfully";
                    else
                        return "Deletion Failed";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
