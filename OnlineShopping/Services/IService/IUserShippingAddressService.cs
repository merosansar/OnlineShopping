using OnlineShopping.DataAccess.Repository;

namespace OnlineShopping.Web.Services.IService
{
    public interface IUserShippingAddressService
    {


        List<ResponseCode> ChangeUserShippingAddress(string flag, int? id, int? userId, string emailAddress, string phoneNo, string shippingAddress);
    }
}
