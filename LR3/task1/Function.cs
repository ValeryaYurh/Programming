namespace Changing.Method
{
    public static class Function
    {
        public static int Changes(int x)
        {
            if(x%2==0) x/=2;
            else if(x%2!=0) x = 0;

            return x;
        }
    }
}