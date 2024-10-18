using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;

namespace OnlineShopping.Web.Services.IService
{
    public interface IProductService
    {
        List<Product> GetProduct(string flag, int Id, string Name, string Description, int CategoryId, decimal Price, int Quantity, string ImageUrl, int SubCatId, int ItemId,int Rating);
        List<ResponseCode> ChangeProduct(string flag, int Id, string Name, string Description, int CategoryId, decimal Price, int Quantity, string ImageUrl, int SubCatId, int ItemId, int Rating);
    }

  
}
