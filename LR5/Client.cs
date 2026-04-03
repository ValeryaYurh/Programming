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
        public string? ClientName 
        { 
            get; 
            set 
            { 
                if (!string.IsNullOrWhiteSpace(value)) ClientName = value;
                else throw new Exception("The name has to have a value"); 
            }  
        }
        private List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            if (order != null) _orders.Add(order);
        }

        public ClientType Type 
        { 
            get; 
            set
            { 
                if (Enum.IsDefined(typeof(ClientType), value)) Type = value; 
                else throw new Exception("The client type is not defined");
            } 
        }

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