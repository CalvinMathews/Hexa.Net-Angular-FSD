-- Create and Use the Database
CREATE DATABASE EmployeeAudit;
USE EmployeeAudit;

--  1
CREATE TABLE Employees (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(100),
    Department VARCHAR(50),
    Salary DECIMAL(10, 2)
);

-- 2
CREATE TABLE EmployeeAuditLog (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    EmpID INT,
    EmpName VARCHAR(100),
    Department VARCHAR(50),
    Salary DECIMAL(10,2),
    ActionType VARCHAR(10),
    ActionDate DATETIME DEFAULT GETDATE()
);

-- sample
INSERT INTO Employees (EmpID, EmpName, Department, Salary) VALUES
(101, 'Faisal Khan', 'IT', 65000.00),
(102, 'Ananya Sharma', 'HR', 48000.00);

SELECT * FROM Employees;

-- sample
INSERT INTO EmployeeAuditLog (EmpID, EmpName, Department, Salary, ActionType) VALUES
(101, 'Faisal Khan', 'IT', 65000.00, 'INSERT'),
(102, 'Ananya Sharma', 'HR', 48000.00, 'INSERT');

SELECT * FROM EmployeeAuditLog;

-- 3
CREATE TRIGGER trg_employee_audit_log
ON Employees
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO EmployeeAuditLog(
        EmpID, EmpName, Department, Salary, ActionType, ActionDate
    )
    SELECT i.EmpID, i.EmpName, i.Department, i.Salary, 'INSERT', GETDATE()
    FROM INSERTED i;
END;

-- 4
CREATE TRIGGER trg_employee_audit_log_delete
ON Employees
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO EmployeeAuditLog(
        EmpID, EmpName, Department, Salary, ActionType, ActionDate
    )
    SELECT d.EmpID, d.EmpName, d.Department, d.Salary, 'DELETE', GETDATE()
    FROM DELETED d;
END;
--5
INSERT INTO Employees (EmpID, EmpName, Department, Salary)
VALUES (103, 'Ravi Patel', 'Finance', 55000.00);

SELECT * FROM EmployeeAuditLog;

DELETE FROM Employees WHERE EmpID = 103;

-- 6
SELECT * FROM EmployeeAuditLog WHERE EmpID = 103;
