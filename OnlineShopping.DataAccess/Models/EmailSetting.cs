using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.DataAccess.Models
{
    public  class EmailSetting
    {
        public string? SmtpServer { get; set; }
        public int SmtpPort { get; set; }  // Change to int
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FromName { get; set; }
        public string? From { get; set; }
    }
}
