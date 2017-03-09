create procedure spDeletePurchase
(@id int)
as
delete from PurchaseTable where PurchaseId=@id