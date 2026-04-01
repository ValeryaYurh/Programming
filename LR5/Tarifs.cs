namespace TarifInformation
{
    public class Tarif
    {
        public string TypeName { get; set; }
        public double TarifValue { get; set; }

        public Tarif(string typeName, double tarifValue)
        {
            TypeName = typeName;
            TarifValue = tarifValue;
        }

    }

}