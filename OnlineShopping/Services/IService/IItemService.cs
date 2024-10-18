using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;

namespace OnlineShopping.Web.Services.IService
{
    public interface IItemService
    {
        List<ResponseCode> AddItemAsync(string flag, Int32? Id, Int32? SubCatId, string Name);
        List<ItemModel> GetItemList(string flag, Int32? Id, Int32? SubCatId, string Name);
        List<ResponseCode> UpdateItem(string flag, Int32? Id, Int32? SubCatId, string Name);
        List<ResponseCode> DeleteItem(string flag, Int32? Id, Int32? SubCatId, string Name);


    }
}
