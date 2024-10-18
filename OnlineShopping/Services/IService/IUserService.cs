using OnlineShopping.DataAccess.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using OnlineShopping.DataAccess.Models;

namespace OnlineShopping.Web.Services.IService
{
    public interface IUserService
    {

     
        List<ResponseCode> ChangeUserInfo(string flag, int? Id, string UserName, string? Email, string PasswordHash, string FullName, string? PhoneNo, string? Address, string? City, string? Province, string? Zone, string? District, string? ProfilePicUrl, int? RoleId,int GenderId,DateTime Dob);

        //List<ResponseCode> LoginResponse(string flag, string UserName, string PasswordHash);
        //PasswordHash ReturnDecryptPassword(string flag, string UserName, string PasswordHash);
    }
}
