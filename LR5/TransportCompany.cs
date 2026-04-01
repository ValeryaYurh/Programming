using TarifInformation;
using OrderInformation;
using ClientsInformation;


namespace TransportCompanyInformaition
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
            set { if (!string.IsNullOrWhiteSpace(value)) _companyName = value; }
        }

       
        public void AddNewTarif(Tarif newTarif)
        {
            if (newTarif != null) _tarifs.Add(newTarif);
        }

        public void AddNewClient(Client newClient)
        {
            if (newClient != null) _clients.Add(newClient);
        }

        public void MakeOrder(Client client, Tarif tarif, double weight)
        {
            Order order = new Order(tarif, weight);

            client.AddOrder(order);

        }

        public double TotalRevenue()
        {
            double sum = 0;

            foreach(var i in _clients)
            {
                sum += i.GetTotalSum();
            }
            
            return sum;
        }

        public static TransportCompany GetInstance()
        {
            if (_instance == null) _instance = new TransportCompany();
            return _instance;
        }

        public Tarif? FindTarifByName(string name)
        {
            foreach (var i in _tarifs)
            {
                if (i.TypeName!.ToLower() == name.ToLower())
                    return i;
            }
            return null;
        }
        public Client? FindClientByName(string name)
        {
            foreach (var i in _clients)
            {
                if (i.ClientName!.ToLower() == name.ToLower())
                    return i;
            }
            return null;
        }

        public void PrintInfo()
        {
            foreach(var i in _clients)
            {
                Console.WriteLine($"\nName of the client: {i.ClientName}\nTotal cost of orders of the client: {i.GetTotalSum()}");
                if(i.Type==ClientType.VIP) Console.WriteLine("Type of client: VIP");
                else Console.WriteLine("Type of client: Regular");
            }
        }
    }
}