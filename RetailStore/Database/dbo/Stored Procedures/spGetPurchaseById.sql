
CREATE procedure [dbo].[spGetPurchaseById]
(@purchaseId int)
as
select * from PurchaseTable where PurchaseId=@purchaseId