using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MimeKit;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using OnlineShopping.Web.Services.IService;
using System.Security.Policy;

namespace OnlineShopping.Web.Services.Service
{
    public class UserShippingAddressService(EshopContext context) : IUserShippingAddressService
    {
        private readonly EshopContext _context = context;
        public List<ResponseCode> ChangeUserShippingAddress(string flag, int? id, int? userId, string emailAddress, string phoneNo, string shippingAddress)
        {
            var pflag = new SqlParameter("@Flag", flag);
            var pid = new SqlParameter("@Id", id);
            var puserId = new SqlParameter("@UserId", userId);
            var pemailAddress = new SqlParameter("@EmailAddress", emailAddress );
            var pphoneNo = new SqlParameter("@PhoneNo", phoneNo);            
            var pshippingAddress = new SqlParameter("@ShippingAddress", shippingAddress);            
            return _context.ResponseCodes.FromSqlRaw("EXECUTE Proc_UserShippingAddress @Flag,@Id,@UserId,@EmailAddress,@PhoneNo,@ShippingAddress", pflag, pid, puserId, pemailAddress, pphoneNo, pshippingAddress).ToList();
        }
    }
}
