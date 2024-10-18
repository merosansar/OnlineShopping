using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;

namespace OnlineShopping.Web.Services.IService
{
    public interface IProductDetailsService
    {
        List<ProductDetails> GetProductDetails(string flag, int Id, int ProductId , string Description, string Specifications, int Brand, string ProductModel, string Warranty, string Material, string Color, string Dimensions,decimal Weight, DateTime? PromotionStartDate, DateTime? PromotionEndDate, decimal? SpecialPrice);
        List<ResponseCode> ChangeProductDetails(string flag, int Id, int ProductId, string Description, string Specifications, int Brand, string ProductModel, string Warranty, string Material, string Color, string Dimensions, decimal Weight, DateTime? PromotionStartDate, DateTime? PromotionEndDate, decimal? SpecialPrice);
    }
}
