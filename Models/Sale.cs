//Venta
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCoder.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public string UserId { get; set; } = ""; 
        public string SaleComments { get; set; } = "";
        public Int32 SaleAmount { get; set; }
        public string Product { get; set; } = "";
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public Int32 Stock { get; set; }
    }
}
