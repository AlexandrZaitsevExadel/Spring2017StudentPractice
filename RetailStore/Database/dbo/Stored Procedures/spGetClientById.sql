
CREATE procedure [dbo].[spGetClientById]
(@id int)
as
select * from ClientTable where ClientId = @id