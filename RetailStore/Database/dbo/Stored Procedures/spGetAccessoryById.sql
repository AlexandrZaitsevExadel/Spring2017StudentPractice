
CREATE procedure [dbo].[spGetAccessoryById]
(@id int)
as
select * from AccessoryTable where AccessoryId = @id