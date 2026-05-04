namespace TarifInformation
{
    public class PercentageDiscount : IDiscountStrategy
    {
        private double _discountPercent;

        public double DiscountPercent
        {
            get { return _discountPercent; }
            set
            {
                if (value >= 0 && value <= 100)
                    _discountPercent = value;
                else
                    throw new Exception("Процент скидки должен быть от 0 до 100");
            }
        }

        public PercentageDiscount(double discountPercent)
        {
            DiscountPercent = discountPercent;
        }

        public string GetDiscountName()
        {
            return $"Скидка {_discountPercent}%";
        }

        public double CalculateDiscount(double basePrice)
        {
            return basePrice * (1 - _discountPercent / 100);
        }
    }
}