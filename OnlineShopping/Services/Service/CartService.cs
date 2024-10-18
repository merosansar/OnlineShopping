using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using OnlineShopping.Web.Services.IService;

namespace OnlineShopping.Web.Services.Service
{
    public class CartService : ICartService
    {
        private readonly EshopContext _context;
        public CartService(EshopContext context)
        {
            _context = context;
        }
        public List<ResponseCode> ChangeCart(string flag, int Id, int UserId,  int CartItemId, int ProductId, int Quantity, decimal Price, bool IsSelected)
        {
           
            
                var pflag = new SqlParameter("@Flag", flag);
                var pId = new SqlParameter("@Id", Id);
                var pUserId = new SqlParameter("@UserId", UserId);
                //var pCartStatusId = new SqlParameter("@CartStatusId", CartStatusId);
                var pCartItemId = new SqlParameter("@CartItemId", CartItemId);
                var pProductId = new SqlParameter("@ProductId", ProductId);    
               
                var pQuantity = new SqlParameter("@Quantity", Quantity);
                var pPrice = new SqlParameter("@Price", Price);
               var pIsSelected = new SqlParameter("@IsSelected", IsSelected);
            return _context.ResponseCodes.FromSqlRaw("EXECUTE Proc_Cart @Flag,@Id,@UserId,@CartItemId,@ProductId,@Quantity,@Price,@IsSelected", pflag, pId, pUserId,  pCartItemId, pProductId, pQuantity, pPrice, pIsSelected).ToList();
          
        }

        public List<Cart> GetCart(string flag, int Id, int UserId, int CartItemId, int ProductId, int Quantity, decimal Price, bool IsSelected)
        {
            var pflag = new SqlParameter("@Flag", flag);
            var pId = new SqlParameter("@Id", Id);
            var pUserId = new SqlParameter("@UserId", UserId);
            //var pCartStatusId = new SqlParameter("@CartStatusId", CartStatusId);
            var pCartItemId = new SqlParameter("@CartItemId", CartItemId);
            var pProductId = new SqlParameter("@ProductId", ProductId);
            var pQuantity = new SqlParameter("@Quantity", Quantity);
            var pPrice = new SqlParameter("@Price", Price);
            var pIsSelected = new SqlParameter("@IsSelected", IsSelected);
         
            return _context.Carts.FromSqlRaw("EXECUTE Proc_Cart @Flag,@Id,@UserId,@CartItemId,@ProductId,@Quantity,@Price,@IsSelected", pflag, pId, pUserId, pCartItemId, pProductId, pQuantity, pPrice, pIsSelected).ToList();
        }

        public List<CartCount> GetCartTotalCount(string flag, int Id, int UserId, int CartItemId, int ProductId, int Quantity, decimal Price, bool IsSelected)
        {
            var pflag = new SqlParameter("@Flag", flag);
            var pId = new SqlParameter("@Id", Id);
            var pUserId = new SqlParameter("@UserId", UserId);
            //var pCartStatusId = new SqlParameter("@CartStatusId", CartStatusId);
            var pCartItemId = new SqlParameter("@CartItemId", CartItemId);
            var pProductId = new SqlParameter("@ProductId", ProductId);

            var pQuantity = new SqlParameter("@Quantity", Quantity);
            var pPrice = new SqlParameter("@Price", Price);
            var pIsSelected = new SqlParameter("@IsSelected", IsSelected);

            return _context.TotalCartCount.FromSqlRaw("EXECUTE Proc_Cart @Flag,@Id,@UserId,@CartItemId,@ProductId,@Quantity,@Price,@IsSelected", pflag, pId, pUserId, pCartItemId, pProductId, pQuantity, pPrice, pIsSelected).ToList();
        }
    }
}
