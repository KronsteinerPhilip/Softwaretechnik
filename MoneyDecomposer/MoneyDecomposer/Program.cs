namespace MoneyDecomposer
{
    static class Program
    {
        static int CopperValue = 1;
        static int SilverValue = 10;
        static int GoldValue = 100;

        static void Main(string[] args)
        {
            Console.WriteLine(Decompose(549));
        }

        public static string Decompose(int totalCopperValue)
        {
            if (totalCopperValue <= CopperValue)
            {
                return "This item is worthless";
            }

            int Gold = (totalCopperValue - (totalCopperValue % GoldValue)) / GoldValue;
            totalCopperValue %= GoldValue;
            int Silver = (totalCopperValue - (totalCopperValue / SilverValue)) / SilverValue;
            int Copper = totalCopperValue % SilverValue;

            string result = Gold > 0 ? $"Gold: {Gold} " : "";
            result += Silver > 0 ? $"Silver: {Silver} " : "";
            result += Copper > 0 ? $"Copper: {Copper} " : "";

            return result;
        }
    }
}