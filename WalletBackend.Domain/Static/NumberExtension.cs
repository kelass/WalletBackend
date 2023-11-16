
namespace WalletBackend.Domain.Static
{
    public static class NumberExtension
    {
        public static string CountCalculate(decimal value)
        {
            string count = string.Empty;

            if (value / 1000000000000m >= 1)
                count = value / 1000000000000m + "Q";

            else if (value / 1000000000m >= 1)
                count = value / 1000000000m + "B";

            else if (value / 1000000m >= 1)
                count = value / 1000000m + "M";

            else if (value / 1000m >= 1)
                count = value / 1000m + "K";

            else
                count = value.ToString();

            return count;
        }
    }
}
