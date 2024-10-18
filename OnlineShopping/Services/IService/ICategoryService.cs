using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;

namespace OnlineShopping.Web.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ResponseCode> AddCategoryAsync(String flag,Int32? Id,String Name,String Description);
        List<ResponseCode> UpdateCategory(string flag, Int32? Id, string Name, string Description);
        List<TblCategory> GetCategory(string flag, Int32? Id, string Name, string Description);
        List<ResponseCode> DeleteCategory(string flag, Int32? Id, string Name, string Description);
    }
}
