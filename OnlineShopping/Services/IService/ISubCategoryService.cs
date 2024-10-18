using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;

namespace OnlineShopping.Web.Services.IService
{
    public interface ISubCategoryService
    {
       List<ResponseCode>  AddSubCategoryAsync(string flag, Int32 Id,Int32? CatId, string Name);
        List<SubCategory> GetSubCatList(string flag, string Name, Int32? Id=0, Int32? CatId=0);



        List<ResponseCode> UpdateSubCategory(string flag, Int32? Id, Int32? CatId, string Name);
       
        List<ResponseCode> DeleteSubCategory(string flag, Int32? Id, Int32? CatId, string Name);
      
    }
}
