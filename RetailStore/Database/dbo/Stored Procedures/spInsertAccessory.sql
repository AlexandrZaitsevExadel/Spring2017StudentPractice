CREATE procedure [dbo].[spInsertAccessory] 
(@name nvarchar(50), @price int)
as
Begin
	insert into AccessoryTable(AccessoryName, Price) values (@name, @price);
	Return SCOPE_IDENTITY();
End