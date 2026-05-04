using TarifInformation;
using OrderInformation;
using ClientsInformation;

namespace TransportCompanyInformation
{
    public class TransportCompany
    {
        private List<Tarif> _tarifs = new List<Tarif>();
        private List<Client> _clients = new List<Client>();
        private string? _companyName;

        private static TransportCompany? _instance;

        private TransportCompany() { }

        public string? CompanyName
        {
            get { return _companyName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _companyName = value;
            }
        }

        public void AddNewTarif(Tarif newTarif)
        {
            if (newTarif != null)
            {
                _tarifs.Add(newTarif);
                Console.WriteLine($"Тариф '{newTarif.TypeName}' успешно добавлен!");
            }
        }

        public void AddNewClient(Client newClient)
        {
            if (newClient != null)
            {
                _clients.Add(newClient);
                Console.WriteLine($"Клиент '{newClient.ClientName}' успешно добавлен!");
            }
        }

        public void MakeOrder(Client client, Tarif tarif, double weight)
        {
            Order order = new Order(tarif, weight);
            client.AddOrder(order);
            Console.WriteLine($"Заказ создан: тариф '{tarif.TypeName}', вес {weight} кг, стоимость {order.GetCost():F2}");
        }

        public double TotalRevenue()
        {
            double sum = 0;
            foreach (var client in _clients)
            {
                sum += client.GetTotalSum();
            }
            return sum;
        }

        public static TransportCompany GetInstance()
        {
            if (_instance == null)
                _instance = new TransportCompany();
            return _instance;
        }

        public Tarif? FindTarifByName(string name)
        {
            foreach (var tarif in _tarifs)
            {
                if (tarif.TypeName!.ToLower() == name.ToLower())
                    return tarif;
            }
            return null;
        }

        public Client? FindClientByName(string name)
        {
            foreach (var client in _clients)
            {
                if (client.ClientName!.ToLower() == name.ToLower())
                    return client;
            }
            return null;
        }

        // Новый метод: поиск тарифа с минимальной стоимостью
        public Tarif? FindMinCostTarif()
        {
            if (_tarifs.Count == 0)
                return null;

            Tarif minTarif = _tarifs[0];
            foreach (var tarif in _tarifs)
            {
                if (tarif.FinalPrice < minTarif.FinalPrice)
                    minTarif = tarif;
            }
            return minTarif;
        }

        // Метод для демонстрации интерфейса
        public void ShowTarifViaInterface()
        {
            if (_tarifs.Count == 0)
            {
                Console.WriteLine("Нет добавленных тарифов!");
                return;
            }

            Console.WriteLine("\n=== Демонстрация вызова через интерфейс ===");
            IDiscountStrategy strategy = _tarifs[0].DiscountStrategy;
            Console.WriteLine($"Стратегия: {strategy.GetDiscountName()}");
            Console.WriteLine($"Расчет цены 1000 руб: {strategy.CalculateDiscount(1000):F2}");
        }

        public void PrintInfo()
        {
            Console.WriteLine($"\n=== Информация о компании: {_companyName} ===");
            
            Console.WriteLine("\n--- Тарифы ---");
            foreach (var tarif in _tarifs)
            {
                Console.WriteLine(tarif.ToString());
            }

            Console.WriteLine("\n--- Клиенты ---");
            foreach (var client in _clients)
            {
                Console.WriteLine($"\nИмя клиента: {client.ClientName}");
                Console.WriteLine($"Общая сумма заказов: {client.GetTotalSum():F2}");
                Console.WriteLine($"Тип клиента: {(client.Type == ClientType.VIP ? "VIP" : "Regular")}");
            }

            var minTarif = FindMinCostTarif();
            if (minTarif != null)
            {
                Console.WriteLine($"\n=== Тариф с минимальной стоимостью ===");
                Console.WriteLine(minTarif.ToString());
            }
        }

        public void PrintAllTarifs()
        {
            if (_tarifs.Count == 0)
            {
                Console.WriteLine("Нет добавленных тарифов!");
                return;
            }

            Console.WriteLine("\n--- Список всех тарифов ---");
            for (int i = 0; i < _tarifs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_tarifs[i].ToString()}");
            }
        }

        public void PrintAllClients()
        {
            if (_clients.Count == 0)
            {
                Console.WriteLine("Нет добавленных клиентов!");
                return;
            }

            Console.WriteLine("\n--- Список всех клиентов ---");
            for (int i = 0; i < _clients.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_clients[i].ClientName} (Тип: {(_clients[i].Type == ClientType.VIP ? "VIP" : "Regular")})");
            }
        }
    }
}