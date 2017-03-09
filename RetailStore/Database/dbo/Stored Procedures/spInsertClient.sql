create procedure spInsertClient
(@name nvarchar(50))
as
insert into ClientTable(ClientId) values (@name)