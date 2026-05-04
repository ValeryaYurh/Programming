using TarifInformation;

namespace OrderInformation
{
    public class Order
    {
        private Tarif _tarif;
        
        public Tarif Tarif
        {
            get { return _tarif; }
            set
            {
                if (value != null)
                    _tarif = value;
                else
                    throw new Exception("Тариф не может быть null");
            }
        }

        private double _weight;
        
        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value > 0)
                    _weight = value;
                else
                    throw new Exception("Вес должен быть положительным числом");
            }
        }

        public Order(Tarif tarif, double weight)
        {
            Tarif = tarif;
            Weight = weight;
        }

        public double GetCost()
        {
            return Tarif.FinalPrice * Weight;
        }
    }
}