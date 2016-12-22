-- Add the DepartmentID column 

ALTER TABLE [Employees] ADD [DepartmentID] 
int NOT NULL 

-- Add a foreign key constraint between Departments.DepartmentID and Employees.DepartmentID
ALTER TABLE [Employees] ADD 
CONSTRAINT [FK_Departments_DepartmentID]
      FOREIGN 
KEY ([DepartmentID]) 
      REFERENCES 
[Departments] ([DepartmentID]) 

-- Remove TotalWeight column from Orders
ALTER TABLE [Orders] DROP COLUMN 
[TotalWeight] 

-- Create the ProductCategories table

CREATE TABLE [ProductCategories]
(
      [ProductCategoryID] 
int IDENTITY(1,1) NOT NULL,
      [CategoryName] 
nvarchar(50) NOT NULL,
      [Active] 
bit NOT NULL CONSTRAINT [DF_ProductCategories_Active]  DEFAULT 
((1)),
      CONSTRAINT 
[PK_ProductCategories] PRIMARY KEY CLUSTERED ( [ProductCategoryID])
)