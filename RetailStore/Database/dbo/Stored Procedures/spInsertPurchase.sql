
CREATE procedure [dbo].[spInsertPurchase]
(@accessoryId int, @clientName nvarchar(50), @quantity int, @purchaseDate datetime)
as
Begin
	DECLARE @clientId int
	IF EXISTS (SELECT ClientId FROM ClientTable WHERE ClientName = @clientName)
	BEGIN
		set @clientId = (select ClientId FROM ClientTable WHERE ClientName = @clientName);
		insert into PurchaseTable(AccessoryId, ClientId, Quantity, PurchaseDate) values (@accessoryId, @clientId, @quantity, @purchaseDate);
		Return SCOPE_IDENTITY();
	END
	ELSE
	BEGIN
		insert into ClientTable(ClientName) values (@clientName)
		insert into PurchaseTable(AccessoryId, ClientId, Quantity, PurchaseDate) values (@accessoryId, SCOPE_IDENTITY(), @quantity, @purchaseDate);
		return SCOPE_IDENTITY();
	END
End