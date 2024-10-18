using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;

namespace OnlineShopping.Web.Services.IService
{
    public interface IUserAuthenticationService
    {
        List<PasswordHashModel> ReturnDecryptPassword(string flag, string UserName, string PasswordHash);
        List<ResponseCode> LoginResponse(string flag, string UserName, string PasswordHash);
    }
}
