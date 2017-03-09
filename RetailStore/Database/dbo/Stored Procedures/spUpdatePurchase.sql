CREATE procedure [dbo].[spUpdatePurchase]
(@id int, @quantity int)
as
update PurchaseTable set Quantity=Quantity+@quantity where PurchaseId=@id