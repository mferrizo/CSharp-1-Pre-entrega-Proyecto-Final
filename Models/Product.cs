//Consulta de Productos
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCoder.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal? Cost { get; set; }
        public decimal? SellingPrice { get; set; }
        public int? Stock { get; set; }
        public int? UserId { get; set; }
    }
}
