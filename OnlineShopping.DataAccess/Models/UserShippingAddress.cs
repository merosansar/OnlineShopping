using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.DataAccess.Models
{
    public class UserShippingAddress
    {
        public int Id { get; set; } // Represents the primary key of the table
        public int UserId { get; set; } // Foreign key or reference to the User table
        public string?  EmailAddress { get; set; } // Stores the user's email address (up to 100 characters)
        public string? PhoneNo { get; set; } // Stores the user's phone number (up to 100 characters)
        public string ?   ShippingAddress { get; set; } // Stores the user's shipping address (up to 200 characters)
    }
}
