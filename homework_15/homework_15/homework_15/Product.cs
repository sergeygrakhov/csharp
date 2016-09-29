using System;
using System.ComponentModel.DataAnnotations;

namespace homework_15
{
    public class Product
    {
        [Key]
        public Int32 Id { get; set; }
        public String ProductName { get; set; }
        public Decimal ProductPrice { get; set; }
        public Sell SellProduct { get; set; }
    }
}
