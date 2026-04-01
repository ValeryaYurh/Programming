using System.Diagnostics.CodeAnalysis;
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
        public string? ClientName { get; set; }
        private List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            if (order != null) _orders.Add(order);
        }

        public ClientType Type { get; set; }

        public double GetTotalSum()
        {
            double sum = 0;
            foreach (var i in _orders)
            {
                sum += i.GetCost();
            }

            if (Type == ClientType.VIP) return sum * 0.9;
            else return sum;
        }

        public Client(string name, ClientType type)
        {
            Type = type;
            ClientName = name;
        }

    }
} 