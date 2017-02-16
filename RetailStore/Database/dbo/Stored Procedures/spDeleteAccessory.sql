create procedure spDeleteAccessory 
(@id int)
as
delete from AccessoryTable where AccessoryId=@id