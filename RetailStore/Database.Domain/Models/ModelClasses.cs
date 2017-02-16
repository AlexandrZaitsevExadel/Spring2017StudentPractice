namespace DBase.Domain.Models
{
    class AccessoryTable
    {

        private int _accessoryId;

        public int AccessoryId
        {
            get
            {
                return _accessoryId;
            }
            set
            {
                _accessoryId = value;
            }
        }

        private string _accessoryName;

        public string AccessoryName
        {
            get
            {
                return _accessoryName;
            }

            set
            {
                _accessoryName = value;
            }
        }

        private int _price;

        public int Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }

    }

    class ClientTable
    {
        private int _clientId;

        public int ClientId
        {
            get
            {
                return _clientId;
            }
            set
            {
                _clientId = value;
            }
        }

        private string _clientName;

        public string ClientName
        {
            get
            {
                return _clientName;
            }

            set
            {
                _clientName = value;
            }
        }


    }

    class PurchaseTable
    {
        private int _purchaseId;

        public int PurchaseId
        {
            get
            {
                return _purchaseId;
            }
            set
            {
                _purchaseId = value;
            }
        }

        private int _accessoryId;

        public int AccessoryId
        {
            get
            {
                return _accessoryId;
            }
            set
            {
                _accessoryId = value;
            }
        }

        private int _clientId;

        public int ClientId
        {
            get
            {
                return _clientId;
            }
            set
            {
                _clientId = value;
            }
        }

        private int _quantity;

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }


    }
}
