using System;
using System.Reflection.Metadata;

namespace Information
{
    public class Tarif
    {
        private string? _typeName;
        private double _tarifValue;
        private double _overallWeight;

        public string? TypeName
        {
            get { return _typeName; }
            set { if (!string.IsNullOrWhiteSpace(value)) _typeName = value; }
        }

        public double TarifValue
        {
            get { return _tarifValue; }
            set { if (value > 0) _tarifValue = value; }
        }

        public double OverAllWeight
        {
            get { return _overallWeight; }
            set { if (value >= 0) _overallWeight = value; }
        }

        public double CalculateRevenue()
        {
            return _tarifValue * _overallWeight;
        }
        public Tarif(string typeName, double tarifValue, double overallWeight)
        {
            TypeName = typeName;
            TarifValue = tarifValue;
            OverAllWeight = overallWeight;
        }

        public double UpTarif(double amount, bool isPercentage)
        {
            if (isPercentage == true) 
            {
                TarifValue += TarifValue * (amount / 100);
                return TarifValue;
            } 
            else
            {
                TarifValue += amount;
                return TarifValue;  
            } 
        }

        public double DownTarif(double amount, bool isPercentage)
        {
            if (isPercentage == true) 
            {
                TarifValue -= TarifValue * (amount / 100);
                return TarifValue;
            } 
            else
            {
                TarifValue -= amount;
                return TarifValue;  
            } 
        }

        public double UpTarif(double amount)
        {
            return UpTarif(amount, false);
        }

        public double DownTarif(double amount)
        {
            return DownTarif(amount, false);
        }

    }
    public class TransportCompany
    {
        private List<Tarif> _tarifs = new List<Tarif>();
        private string? _companyName;

        private static TransportCompany? _instance;

        private TransportCompany() { }
        public string? CompanyName
        {
            get { return _companyName; }
            set { if (!string.IsNullOrWhiteSpace(value)) _companyName = value; }
        }

        public double CalculateTotalRevenue()
        {
            double total = 0;

            foreach (var i in _tarifs)
            {
                total += i.CalculateRevenue();
            }

            return total;
        }

        public void AddNewTarif(Tarif newTarif)
        {
            if (newTarif != null) _tarifs.Add(newTarif);
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

        public void PrintInfo()
        {
            foreach(var i in _tarifs)
            {
                Console.WriteLine($"\nНазвание тарифа: {i.TypeName}\nТариф(за тонну): {i.TarifValue}\nПеревезённый вес(тонн): {i.OverAllWeight}\nВыручка за тариф: {i.CalculateRevenue()}\n");
            }
        }

    }
}