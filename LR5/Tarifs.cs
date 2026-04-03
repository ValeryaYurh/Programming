namespace TarifInformation
{
    public class Tarif
    {
        public string TypeName 
        { 
            get; 
            set 
            { 
                if (!string.IsNullOrWhiteSpace(value)) TypeName = value;
                else throw new Exception("The name has to have a value"); 
            } 
            
        }
        public double TarifValue
        {
            get;
            set
            {
                if (value > 0) TarifValue = value;
                if (value <= 0) throw new Exception("Tarif value must be a positive number");
            }
        }

        public Tarif(string typeName, double tarifValue)
        {
            TypeName = typeName;
            TarifValue = tarifValue;
        }

    }

}