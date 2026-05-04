namespace TarifInformation
{
    public interface IDiscountStrategy
    {
        string GetDiscountName();
        double CalculateDiscount(double basePrice);
    }
}