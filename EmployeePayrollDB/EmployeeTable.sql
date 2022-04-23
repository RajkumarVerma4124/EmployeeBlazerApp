create database EmployeePayrollDB;
use EmployeePayrollDB;

CREATE TABLE EmployeePayroll (
    EmployeeId int unsigned auto_increment primary key not null,
    Name varchar(255) not null,
	ProfileImg varchar(255) not null,	
    Gender char(1) not null,
	Department varchar(25) not null,
	Salary varchar(20) not null,
	StartDate date not null,
    Notes varchar(5000) not null
); 
Drop Table EmployeePayroll;

#For ALtering The Table DataType 
ALTER TABLE EmployeePayroll
MODIFY COLUMN Notes Text;
ALTER TABLE EmployeePayroll
MODIFY COLUMN Gender varchar(10) not null;

#Design Of The Table
describe EmployeePayroll;

insert into EmployeePayroll(Name, ProfileImg, Gender, Department, Salary, StartDate, Notes )values('Raj Verma', 'Raj.png', 'Male', 'IT', '45000', '21-06-15', 'First Entry');
insert into EmployeePayroll(Name, ProfileImg, Gender, Department, Salary, StartDate, Notes )
		values('Yash Verma', 'Yash.png', 'Male', 'Devops', '55000', '21-04-15', 'Second Entry'),
			  ('Mansi Verma', 'Mansi.png', 'Female', 'Finanace', '35000', '22-03-15', 'Third Entry');		

Select * from EmployeePayroll;

#Calling Stored Procedure

#Get All Employee
Call sp_GetAllEmployee();

#Add Employee
Call sp_AddEmployee('Ajay Matkar', 'Ajay.png', 'Male', 'IT-Developer', '35000', '22-04-15', 'Fourth Entry');
#Get Single Employee
Call sp_GetEmployee(2);
#Delete Single Employee
Call sp_DeleteEmployee(4);

#Update Single Employee
Call sp_UpdateEmployee('5', 'Ajay Matkar', 'Ajay.png', 'Male', 'Software-Developer', '33000', '22-04-15', 'Update Entry');