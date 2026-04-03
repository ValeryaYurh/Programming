using TarifInformation;

namespace OrderInformation
{
    public class Order
    {
        public Tarif Tarif 
        { 
            get; 
            set
            { 
                if (value != null) Tarif = value; 
                else throw new Exception("The tarif is not defined");
            } 
        }
        public double Weight
        { 
            get; 
            set 
            { 
                if(value>0) Weight = value; 
                if(value<=0) throw new Exception("Weight must be a positive number");
            } 
        }

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