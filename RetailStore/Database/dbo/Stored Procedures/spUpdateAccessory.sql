CREATE procedure [dbo].[spUpdateAccessory] 
(@id int, @name nvarchar(50), @price int)
as
update AccessoryTable set AccessoryName=@name, Price=@price where AccessoryId=@id