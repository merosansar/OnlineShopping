using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.DataAccess.Models
{
    public class OrderDetailResult
    {

       
        
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }

        public string? ProductName { get; set; }

        public int? OrderId { get; set; }

        public bool IsApproved { get; set; } = false;
       
     
    }
}
