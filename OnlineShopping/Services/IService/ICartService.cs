using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;

namespace OnlineShopping.Web.Services.IService
{
    public interface ICartService
    {

        //List<TblCart> GetCartItem(string flag, int Id, int UserId, int CartStatusId, int CartItemId, int ProductId, int Quantity, decimal Price);
        List<ResponseCode> ChangeCart(string flag, int Id, int UserId,  int CartItemId, int ProductId, int Quantity, decimal Price,bool IsSelected);

        List<Cart> GetCart(string flag, int Id, int UserId, int CartItemId, int ProductId, int Quantity, decimal Price, bool IsSelected);

        List<CartCount> GetCartTotalCount(string flag, int Id, int UserId, int CartItemId, int ProductId, int Quantity, decimal Price, bool IsSelected);

    }
}
