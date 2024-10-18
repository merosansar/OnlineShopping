using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using OnlineShopping.Web.Services.IService;

namespace OnlineShopping.Web.Services.Service
{
    public class UserAuthenticationService(EshopContext context) : IUserAuthenticationService
    {
        private readonly EshopContext _context = context;

        public List<ResponseCode> LoginResponse(string flag, string UserName, string PasswordHash)
        {
            var pflag = new SqlParameter("@Flag", flag);
            var pUserName = new SqlParameter("@UserName", UserName);
            var pPasswordHash = new SqlParameter("@PasswordHash", PasswordHash);
            return _context.ResponseCodes.FromSqlRaw("EXECUTE Proc_UserAuthentication @Flag, @UserName,@PasswordHash", pflag, pUserName, pPasswordHash).ToList();
        }

        public List<PasswordHashModel> ReturnDecryptPassword(string flag, string UserName, string PasswordHash)
        {
            var pflag = new SqlParameter("@Flag", flag);
            var pUserName = new SqlParameter("@UserName", UserName);
            var pPasswordHash = new SqlParameter("@PasswordHash", PasswordHash);
            return _context.PasswordHashModel.FromSqlRaw("EXECUTE Proc_UserAuthentication @Flag,@UserName,@PasswordHash", pflag, pUserName, pPasswordHash).ToList();
        }
    }
}
