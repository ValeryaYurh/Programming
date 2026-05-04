namespace TarifInformation
{
    public class NoDiscount : IDiscountStrategy
    {
        public string GetDiscountName()
        {
            return "Без скидки";
        }

        public double CalculateDiscount(double basePrice)
        {
            return basePrice;
        }
    }
}