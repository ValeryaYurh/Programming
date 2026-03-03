namespace Services.Task2
{
    public static class FunctionalCalc
    {
        public static double Calculation(double z, double b)
        {
            double x = z < 1 ? z / b : Math.Sqrt(Math.Pow(z * b, 3));

            double y = -Math.PI + Math.Pow(Math.Cos(Math.Pow(x, 3)), 2) + Math.Pow(Math.Sin(Math.Pow(x, 2)), 3);

            return y;
        }
    }
}