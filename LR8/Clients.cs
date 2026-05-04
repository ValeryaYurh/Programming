using OrderInformation;

namespace ClientsInformation
{
    public enum ClientType
    {
        Regular,
        VIP
    }

    public class Client
    {
        private string _clientName;
        
        public string ClientName
        {
            get { return _clientName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _clientName = value;
                else
                    throw new Exception("Имя клиента не может быть пустым");
            }
        }

        private List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            if (order != null)
                _orders.Add(order);
        }

        private ClientType _type;
        
        public ClientType Type
        {
            get { return _type; }
            set
            {
                if (Enum.IsDefined(typeof(ClientType), value))
                    _type = value;
                else
                    throw new Exception("Неверный тип клиента");
            }
        }

        public double GetTotalSum()
        {
            double sum = 0;
            foreach (var order in _orders)
            {
                sum += order.GetCost();
            }

            if (_type == ClientType.VIP)
                return sum * 0.9;
            else
                return sum;
        }

        public Client(string name, ClientType type)
        {
            ClientName = name;
            Type = type;
        }
    }
}