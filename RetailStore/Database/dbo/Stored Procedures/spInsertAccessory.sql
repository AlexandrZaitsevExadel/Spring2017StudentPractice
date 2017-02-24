create procedure spInsertAccessory 
(@id int, @name nvarchar(50), @price int)
as
Begin
	insert into AccessoryTable(AccessoryId, AccessoryName, Price) values (@id, @name, @price);
	RETURN SCOPE_IDENTITY();
End