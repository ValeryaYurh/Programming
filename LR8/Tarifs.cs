namespace TarifInformation
{
    public class Tarif
    {
        private string _typeName;
        private double _tarifValue;
        private IDiscountStrategy _discountStrategy;

        public string TypeName
        {
            get { return _typeName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _typeName = value;
                else
                    throw new Exception("Название тарифа не может быть пустым");
            }
        }

        public double TarifValue
        {
            get { return _tarifValue; }
            set
            {
                if (value > 0)
                    _tarifValue = value;
                else
                    throw new Exception("Значение тарифа должно быть положительным числом");
            }
        }

        public IDiscountStrategy DiscountStrategy
        {
            get { return _discountStrategy; }
            set
            {
                if (value != null)
                    _discountStrategy = value;
                else
                    throw new Exception("Стратегия скидки не может быть null");
            }
        }

        public double FinalPrice
        {
            get { return _discountStrategy.CalculateDiscount(_tarifValue); }
        }

        public Tarif(string typeName, double tarifValue, IDiscountStrategy discountStrategy)
        {
            TypeName = typeName;
            TarifValue = tarifValue;
            _discountStrategy = discountStrategy ?? new NoDiscount();
        }

        public Tarif(string typeName, double tarifValue) : this(typeName, tarifValue, new NoDiscount())
        {
        }

        public void ApplyDiscountStrategy(IDiscountStrategy strategy)
        {
            _discountStrategy = strategy;
        }

        public override string ToString()
        {
            return $"Тариф: {TypeName}, Базовая цена: {_tarifValue:F2}, {_discountStrategy.GetDiscountName()}, Итоговая: {FinalPrice:F2}";
        }
    }
}