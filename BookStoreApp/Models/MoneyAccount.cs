using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookStoreApp.Models
{
    public enum DiscountCardType
    {
        Silver,
        Golden
    }

    public class DiscountCard
    {
        [Key]
        [ForeignKey("MoneyAccount")]
        public string Id { get; set; }
        public DiscountCardType? CardType { get; set; }

        public MoneyAccount MoneyAccount { get; set; }

        public int GetDiscountPercentage()
        {
            switch (CardType)
            {
                case DiscountCardType.Silver:
                    return Settings.DiscountPolicy.SilverDiscount;
                case DiscountCardType.Golden:
                    return Settings.DiscountPolicy.GoldenDiscount;
                default:
                    return Settings.DiscountPolicy.DefaultDiscount;
            }
        }
    }

    public class MoneyAccount
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public double Balance { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public DiscountCard DiscountCard { get; set; }
    }
}