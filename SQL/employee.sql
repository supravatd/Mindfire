CREATE DATABASE testdb; /* create database */

USE testdb;

CREATE TABLE Employee  
(  
EmployeeID int,  
FirstName varchar(255),  
LastName varchar(255),  
Email varchar(255),  
AddressLine varchar(255),  
City varchar(255)  
);  

INSERT INTO Employee (EmployeeID, FirstName, LastName, Email, AddressLine, City)
VALUES ('101', 'Lucas', 'Santos', 'lucassantos@gmail.com', 'Brazil', 'Sao Paulo'),
('102', 'Carlos', 'Santiago', 'carlossantiago@gmail.com', 'Argentina', 'Buenos Aires'),
('103', 'Emanuel', 'DaSilva', 'emanueldasilva@gmail.com', 'Brazil', 'Rio Grande do Sul'),
('104', 'Abril', 'Rodriguez', 'abrilrodrigues@gmail.com', 'Argentina', 'Mendoza'),
('105', 'Carolina', 'Bentresca', 'carolinabentresca@gmail.com', 'Chile', 'Concepsion'),
('106', 'Carol', 'Santos', 'carolsantos@gmail.com', 'Chile', 'Santiago'),
('107', 'Gabriela', 'Lopez', 'Gabrielalopez@gmail.com', 'Brazil', 'Amazonas'),
('108', 'Michael', 'DeCarvalho', 'michaeldecarvalho@gmail.com', 'Brazil', 'Fortaleza'),
('109', 'George', 'Spencer', 'georgespencer@gmail.com', 'United Kingdom', 'London'),
('110', 'Christina', 'Diemert', 'christinadiemert@gmail.com', 'United States', 'California');

SELECT * FROM Employee;

SELECT FirstName, LastName, City FROM Employee;

SELECT DISTINCT AddressLine 
FROM Employee;

SELECT * FROM Employee WHERE AddressLine = 'Brazil';
SELECT * FROM Employee WHERE City = 'Sao Paulo';

SELECT * FROM Employee ORDER BY LastName ASC;

SELECT COUNT(*) FROM Employee;

SELECT AVG(EmployeeID) FROM Employee;
SELECT SUM(EmployeeID) FROM Employee;
SELECT MIN(EmployeeID) FROM Employee;
SELECT MAX(EmployeeID) FROM Employee;

SELECT AddressLine, AVG(EmployeeID) FROM Employee GROUP BY AddressLine;

CREATE TABLE Department (
    DepartmentID int,
    DepartmentName varchar(255)
);

INSERT INTO Department (DepartmentID, DepartmentName)
VALUES (101, 'IT'),
       (102, 'Finance'),
       (103, 'Sales');

SELECT Employee.*, Department.DepartmentName
FROM Employee
INNER JOIN Department ON Employee.EmployeeID = Department.DepartmentID;

SELECT * FROM Employee WHERE AddressLine IN ('Brazil', 'Argentina');

SELECT * FROM Employee WHERE EmployeeID > (SELECT AVG(EmployeeID) FROM Employee);

UPDATE Employee SET City = 'New York' WHERE LastName = 'Spencer';

DELETE FROM Employee WHERE AddressLine = 'Chile';

CREATE INDEX idx_City ON Employee(City);

SELECT e.FirstName, e.LastName, d.DepartmentName
FROM Employee AS e
LEFT JOIN Department AS d ON e.EmployeeID = d.DepartmentID;

SELECT Email FROM Employee WHERE FirstName='Chri''stina';