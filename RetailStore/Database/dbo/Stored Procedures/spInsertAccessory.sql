create procedure spInsertAccessory 
(@id int, @name nvarchar(50), @price int)
as
insert into AccessoryTable(AccessoryId, AccessoryName, Price) values (@id, @name, @price)