using TarifInformation;

namespace OrderInformation
{
    public class Order{
        public Tarif Tarif{ get; set; }
        public double Weight{ get; set; }

        public Order(Tarif tarif, double weight)
        {
            Tarif = tarif;
            Weight = weight;
        }

        public double GetCost()
        {
            return Tarif.TarifValue * Weight;
        }
    }
}