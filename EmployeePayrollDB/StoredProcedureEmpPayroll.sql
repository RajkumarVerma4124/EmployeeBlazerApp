#Stored Procedure For Adding Employee
CREATE DEFINER=`RAJVERMA`@`localhost` PROCEDURE `sp_AddEmployee`(
	Name varchar(255),
	ProfileImg varchar(255),	
    Gender varchar(10),
	Department varchar(25),
	Salary varchar(20),
	StartDate date,
    Notes varchar(5000)
)
BEGIN
Insert Into EmployeePayroll(Name, ProfileImg, Gender, Department, Salary, StartDate, Notes)
				values(Name, ProfileImg, Gender, Department, Salary, StartDate, Notes);
END

#Stored Procedure For Deleting Employee
sp_DeleteEmployee
CREATE DEFINER=`RAJVERMA`@`localhost` PROCEDURE `sp_DeleteEmployee`(Id int)
BEGIN
Delete From EmployeePayroll Where EmployeeId = Id;
END

#Stored Procedure For Getting A Single Employee
sp_GetAllEmployee
CREATE DEFINER=`RAJVERMA`@`localhost` PROCEDURE `sp_GetAllEmployee`()
BEGIN
Select * From EmployeePayroll;
END

#Stored Procedure For Getting A List Of Employee
sp_GetEmployee
CREATE DEFINER=`RAJVERMA`@`localhost` PROCEDURE `sp_GetEmployee`(Id int)
BEGIN
Select * From EmployeePayroll Where EmployeeId = Id;
END

#Stored Procedure For Updating A Employee
sp_UpdateEmployee
CREATE DEFINER=`RAJVERMA`@`localhost` PROCEDURE `sp_UpdateEmployee`(
	Id int,
	EmpName varchar(255),
	EmpProfileImg varchar(255),	
    	EmpGender varchar(10),
	EmpDepartment varchar(25),
	EmpSalary varchar(20),
	EmpStartDate date,
    	EmpNotes varchar(5000)
)
BEGIN
update EmployeePayroll Set Name = EmpName, ProfileImg = EmpProfileImg, Gender = EmpGender, Department = EmpDepartment, Salary = EmpSalary, StartDate = EmpStartDate, Notes = EmpNotes Where EmployeeId = Id;
END
