using System;
using ClientsInformation;
using Microsoft.VisualBasic;
using TarifInformation;
using TransportCompanyInformaition;


namespace Lab5
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Вариант 7\nФирма грузоперевозок");
            Console.WriteLine("For VIP clients discount is 10%");
            
            TransportCompany company = TransportCompany.GetInstance();

            Tarif tarif1 = new Tarif("Fuel", 300);
            Tarif tarif2 = new Tarif("Gaz", 432);

            company.AddNewTarif(tarif1);
            company.AddNewTarif(tarif2);

            Client client1 = new Client("Valerya", ClientType.VIP);
            Client client2 = new Client("Marya", ClientType.Regular);

            company.AddNewClient(client1);
            company.AddNewClient(client2);

            company.MakeOrder(client1, tarif1, 3.62);
            company.MakeOrder(client2, tarif1, 13.11);
            company.MakeOrder(client1, tarif2, 2.21);
            company.MakeOrder(client2, tarif2, 0.34);

            Console.WriteLine(company.FindClientByName("valerya"));

            Console.WriteLine($"Total revenue : {company.TotalRevenue()}");
            company.PrintInfo();
        
        }
    }
}
