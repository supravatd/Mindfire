CREATE TABLE Employees (
    Employee_Id INT PRIMARY KEY,
    Employee_Name VARCHAR(255) NOT NULL,
    Manager_Id INT,
    Date_of_Birth DATE,
    Hire_Date DATE,
    Job_title VARCHAR(100),
    Salary DECIMAL(10, 2),
    Department VARCHAR(50),
    FOREIGN KEY (Manager_id) REFERENCES employees(employee_id)
);

-- Inserting values into the employees table
INSERT INTO employees (employee_id, employee_name, manager_id, date_of_birth, hire_date, job_title, salary, department)
VALUES
    (1, 'John Doe', NULL, '1980-01-15', '2020-05-01', 'Manager', 60000.00, 'HR'),
    (2, 'Jane Smith', 1, '1990-07-20', '2021-02-15', 'Employee', 45000.00, 'IT'),
    (3, 'Bob Johnson', 1, '1985-03-10', '2018-09-01', 'Employee', 50000.00, 'Finance'),
    (4, 'Alice Davis', 1, '1992-11-25', '2019-04-12', 'Employee', 48000.00, 'HR'),
    (5, 'Mark Williams', 2, '1988-06-05', '2022-03-20', 'Employee', 47000.00, 'IT'),
    (6, 'Emma White', 2, '1995-09-12', '2023-01-10', 'Employee', 49000.00, 'Finance'),
    (7, 'Chris Taylor', 3, '1983-04-18', '2021-08-15', 'Employee', 52000.00, 'HR'),
    (8, 'Sophia Brown', 3, '1998-02-28', '2023-05-05', 'Employee', 48000.00, 'IT'),
    (9, 'David Miller', 4, '1991-08-08', '2017-12-01', 'Employee', 51000.00, 'Finance'),
    (10, 'Olivia Wilson', 4, '1994-12-22', '2020-10-18', 'Employee', 47000.00, 'HR');

--LEFT JOIN
SELECT
    e.*
FROM
    employees e LEFT JOIN employees m 
	ON e.manager_id = m.employee_id
	where e.employee_id=(Select Manager_Id from Employees where Employee_Id=2);

SELECT
    e.Employee_Name, m.employee_name AS manager_name
FROM
    employees e
LEFT JOIN
    employees m ON e.manager_id = m.employee_id
WHERE
    e.employee_id = 3;


--RIGHT JOIN
SELECT *
FROM Employees
RIGHT JOIN Departments ON Employees.Department = Departments.Department;


--STORED PROCEDURES
CREATE PROCEDURE SelectAllEmployees
AS
SELECT * FROM Employees

EXEC SelectAllEmployees;


--USER DEFINED FUNC
CREATE FUNCTION salary()
RETURNS INT
AS
BEGIN
    DECLARE @count INT;
    
    SELECT @count = COUNT(*)
    FROM Employees
    WHERE Salary > 50000;
    
    RETURN @count;
END;

SELECT dbo.salary() AS TotalEmployees;

--VIEWS
CREATE VIEW [John Employees] AS
SELECT Employee_ID, Employee_name
FROM Employees
WHERE Manager_Id = 1;

Select * from [John Employees];


--NULL FUNC
SELECT iSNULL(NULL, 'TEST')
SELECT coalesce(NULL, null, 'TEST')

--VARIABLES
DECLARE @count INT;
DECLARE @avgsal DECIMAL(10, 2);

SET @count = (SELECT COUNT(*) FROM Employees);
SET @avgsal = (SELECT AVG(Salary) FROM Employees);

PRINT 'Total Number of Employees: ' + CAST(@count AS VARCHAR);
PRINT 'Average Salary: ' + CAST(@avgsal AS VARCHAR);

--TRIGERS
