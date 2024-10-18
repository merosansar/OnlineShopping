using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using OnlineShopping.Web.Services.IService;

namespace OnlineShopping.Web.Services.Service
{
    public class ProductService(EshopContext context) : IProductService
    {
        private readonly EshopContext _context = context;

        public List<ResponseCode> ChangeProduct(string flag, int Id, string Name, string Description, int CategoryId, decimal Price, int Quantity, string ImageUrl, int SubCatId, int ItemId, int Rating)
        {
            var pflag = new SqlParameter("@Flag", flag);
            var pId = new SqlParameter("@Id", Id);
            var pName = new SqlParameter("@Name", Name);
            var pDescription = new SqlParameter("@Description", Description);
            var pCategoryId = new SqlParameter("@CategoryId", CategoryId);
            var pPrice = new SqlParameter("@Price", Price);
            var pQuantity = new SqlParameter("@Quantity", Quantity);
            var pImageUrl = new SqlParameter("@ImageUrl", ImageUrl);
            var pSubCatId = new SqlParameter("@SubCatId", SubCatId);
            var pItemId = new SqlParameter("@ItemId", ItemId);
            var pRating = new SqlParameter("@Rating", Rating);
            return _context.ResponseCodes.FromSqlRaw("EXECUTE Proc_Product @Flag,@Id,@Name,@Description,@CategoryId,@Price,@Quantity,@ImageUrl,@SubCatId,@ItemId,@Rating", pflag, pId, pName, pDescription, pCategoryId, pPrice, pQuantity, pImageUrl, pSubCatId, pItemId,pRating).ToList();
        }

        public List<Product> GetProduct(string flag, int Id, string Name, string Description, int CategoryId, decimal Price, int Quantity, string ImageUrl, int SubCatId, int ItemId, int Rating)
        {
            var pflag = new SqlParameter("@Flag", flag);
            var pId = new SqlParameter("@Id", Id);
            var pName = new SqlParameter("@Name", Name);
            var pDescription = new SqlParameter("@Description", Description);
            var pCategoryId = new SqlParameter("@CategoryId", CategoryId);
            var pPrice = new SqlParameter("@Price", Price);
            var pQuantity = new SqlParameter("@Quantity", Quantity);
            var pImageUrl = new SqlParameter("@ImageUrl", ImageUrl);
            var pSubCatId = new SqlParameter("@SubCatId", SubCatId);
            var pItemId = new SqlParameter("@ItemId", ItemId);
            var pRating = new SqlParameter("@Rating", Rating);

            return _context.Product.FromSqlRaw("EXECUTE Proc_Product @Flag,@Id,@Name,@Description,@CategoryId,@Price,@Quantity,@ImageUrl,@SubCatId,@ItemId,@Rating", pflag, pId, pName, pDescription, pCategoryId, pPrice, pQuantity, pImageUrl, pSubCatId, pItemId, pRating).ToList();


        }
    }
}


       