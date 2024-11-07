CREATE VIEW [dbo].[SearchGlobal1]
AS
SELECT        dbo.Customers.ID AS IDCUSTOMER, dbo.Projects.ID AS IDPROJECT, dbo.Customers.CompanyName, dbo.Customers.PhoneNumbe, dbo.Customers.FullName, dbo.Customers.CompanyNumber, 
                         dbo.Customers.AccountantNumber, dbo.Projects.ProjectName, dbo.Projects.ProjectNumber, dbo.Projects.Notes, dbo.Projects.Address, dbo.Projects.Manger, dbo.Orders.OrderNumber, dbo.Orders.ID AS IDORDER
FROM            dbo.Customers INNER JOIN
                         dbo.Projects ON dbo.Customers.ID = dbo.Projects.IDcustomer INNER JOIN
                         dbo.Orders ON dbo.Projects.ID = dbo.Orders.ProjectID
GO
