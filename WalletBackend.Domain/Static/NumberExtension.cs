
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WalletBackend.Domain.Static
{
    public static class NumberExtension
    {
        public static string CountCalculate(decimal value)
        {
            string count = string.Empty;

            if (value / 1000000000000m >= 1)
            {
                decimal result = Math.Round(value / 1000000000000m, MidpointRounding.AwayFromZero);
                count = result + "Q";
            }

            else if (value / 1000000000m >= 1)
            {
                decimal result = Math.Round(value / 1000000000m, MidpointRounding.AwayFromZero);
                count = result + "B";
            }

            else if (value / 1000000m >= 1)
            {
                decimal result = Math.Round(value / 1000000m, MidpointRounding.AwayFromZero);
                count = result + "M";
            }

            else if (value / 1000m >= 1)
            {
                decimal result = Math.Round(value / 1000m, MidpointRounding.AwayFromZero);
                count = result + "K";
            }

            else
                count = value.ToString();

            return count;
        }
    }
}
