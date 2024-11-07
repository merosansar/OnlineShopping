using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using OnlineShopping.Web.Services.IService;
using System.Drawing;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;

namespace OnlineShopping.Web.Services.Service
{
    public class UserService(EshopContext context) : IUserService


    {
        private readonly EshopContext _context = context;

        public List<ResponseCode> ChangeUserInfo(string flag, int? Id, string UserName, string? Email, string PasswordHash, string FullName, string? PhoneNo, string? Address, string? City, string? Province, string? Zone, string? District, string? ProfilePicUrl, int? RoleId, int GenderId, DateTime Dob)
        {
           
            var pflag = new SqlParameter("@Flag", flag);
            var pId = new SqlParameter("@Id", Id);
            var pUserName = new SqlParameter("@UserName", UserName);
            var pEmail = new SqlParameter("@Email", (object?)Email ?? DBNull.Value);
            var pPasswordHash = new SqlParameter("@PasswordHash", PasswordHash);
            var pFullName = new SqlParameter("@FullName", FullName);
            var pPhoneNo = new SqlParameter("@PhoneNo", (object?)PhoneNo ?? DBNull.Value);
            var pAddress = new SqlParameter("@Address", (object?)Address ?? DBNull.Value);
            var pCity = new SqlParameter("@City", (object?)City ?? DBNull.Value);
            var pProvince = new SqlParameter("@Province", (object?)Province ?? DBNull.Value);
            var pZone = new SqlParameter("@Zone", (object?)Zone ?? DBNull.Value);
            var pDistrict = new SqlParameter("@District", (object?)District ?? DBNull.Value);
            var pProfilePicUrl = new SqlParameter("@ProfilePicUrl", (object?)ProfilePicUrl ?? DBNull.Value);

            var pRoleId = new SqlParameter("@RoleId", (object?)RoleId ?? DBNull.Value);
            var pGenderId = new SqlParameter("@GenderId", GenderId);
            var pDob = new SqlParameter("@Dob", Dob);
            return [.. _context.ResponseCodes.FromSqlRaw("EXECUTE Proc_User @Flag,@Id,@UserName,@Email,@PasswordHash,@FullName,@PhoneNo,@Address,@City,@Province,@Zone,@District,@ProfilePicUrl,@RoleId,@GenderId,@Dob", pflag, pId, pUserName, pEmail, pPasswordHash, pFullName, pPhoneNo, pAddress, pCity, pProvince, pZone, pDistrict, pProfilePicUrl, pRoleId, pGenderId, pDob)];
        }
      

        //public List<ResponseCode> LoginResponse( string flag ,string UserName, string PasswordHash)
        //{
        //    var pflag = new SqlParameter("@Flag", flag);
        //    var pUserName = new SqlParameter("@UserName", UserName);            
        //    var pPasswordHash = new SqlParameter("@PasswordHash", PasswordHash);
        //    return _context.ResponseCodes.FromSqlRaw("EXECUTE Proc_UserAuthentication @Flag, @UserName,@PasswordHash", pflag, pUserName, pPasswordHash).ToList();
        //}

        //public PasswordHash ReturnDecryptPassword(string UserName, string PasswordHash)
        //{
        //    var pUserName = new SqlParameter("@UserName", UserName);
        //    var pPasswordHash = new SqlParameter("@PasswordHash", PasswordHash);
        //    return  (PasswordHash) _context.PasswordHash.FromSqlRaw("EXECUTE Proc_UserAuthentication @Flag, @UserName,@PasswordHash", pUserName, pPasswordHash);
        //}

        //public PasswordHash ReturnDecryptPassword(string flag, string UserName, string PasswordHash)
        //{
        //    var pUserName = new SqlParameter("@UserName", UserName);
        //    var pPasswordHash = new SqlParameter("@PasswordHash", PasswordHash);
        //    return (PasswordHash)_context.PasswordHash.FromSqlRaw("EXECUTE Proc_UserAuthentication @UserName,@PasswordHash", pUserName, pPasswordHash);
        //}
    }
}
