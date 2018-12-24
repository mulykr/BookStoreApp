using System.Configuration;

namespace BookStoreApp.Models
{
    public class DiscountPolicy
    {
        public int SilverDiscount => int.Parse(ConfigurationManager.AppSettings["Silver"]);

        public int GoldenDiscount => int.Parse(ConfigurationManager.AppSettings["Golden"]);

        public int DefaultDiscount => int.Parse(ConfigurationManager.AppSettings["Default"]);
    }

    public class Settings
    {
        static Settings()
        {
            DiscountPolicy = new DiscountPolicy();
        }

        public static DiscountPolicy DiscountPolicy { get; }
    }
}