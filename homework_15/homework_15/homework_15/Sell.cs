using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace homework_15
{
    public class Sell
    {
        [Key]
        [ForeignKey("Product")]
        public Int32 Id { get; set; }
        public Decimal SellSum { get; set; }
        public Product Product { get; set; }
    }
}
