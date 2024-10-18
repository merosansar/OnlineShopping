using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using OnlineShopping.Web.Services.IService;

namespace OnlineShopping.Web.Services.Service
{
    public class ItemService : IItemService
    {
        private readonly EshopContext _context;
        public ItemService(EshopContext context)
        {
            _context = context;
        }
        public List<ResponseCode> AddItemAsync(string flag, int? Id, int? SubCatId, string Name)
        {
            var pflag = new SqlParameter("@Flag", flag);
            var pId = new SqlParameter("@Id", Id);
            var pName = new SqlParameter("@Name", Name);
            var pSubCatId = new SqlParameter("@SubCatId", SubCatId);
            return _context.ResponseCodes.FromSqlRaw("EXECUTE Proc_Item @Flag ,@Id,@Name,@SubCatId", pflag, pId, pName, pSubCatId).ToList();
        }

        public List<ResponseCode> DeleteItem(string flag, int? Id, int? SubCatId, string Name)
        {
            var pflag = new SqlParameter("@Flag", flag);
            var pId = new SqlParameter("@Id", Id);
            var pName = new SqlParameter("@Name", Name);
            var pSubCatId = new SqlParameter("@SubCatId", SubCatId);
            return _context.ResponseCodes.FromSqlRaw("EXECUTE Proc_Item @Flag ,@Id,@Name,@SubCatId", pflag, pId, pName, pSubCatId).ToList();
        }

        public List<ItemModel> GetItemList(string flag, int? Id, int? SubCatId, string Name)
        {
            var pflag = new SqlParameter("@Flag", flag ?? (object)DBNull.Value);
            var pId = new SqlParameter("@Id", Id.HasValue ? (object)Id.Value : DBNull.Value);
            var pName = new SqlParameter("@Name", Name ?? (object)DBNull.Value);
            var pSubCatId = new SqlParameter("@SubCatId", SubCatId.HasValue ? (object)SubCatId.Value : DBNull.Value);
            return _context.ItemList.FromSqlRaw("EXECUTE Proc_Item @Flag ,@Id,@Name,@SubCatId", pflag, pId, pName, pSubCatId).ToList();
        }

        public List<ResponseCode> UpdateItem(string flag, int? Id, int? SubCatId, string Name)
        {
            var pflag = new SqlParameter("@Flag", flag);
            var pId = new SqlParameter("@Id", Id);
            var pName = new SqlParameter("@Name", Name);
            var pSubCatId = new SqlParameter("@SubCatId", SubCatId);
            return _context.ResponseCodes.FromSqlRaw("EXECUTE Proc_Item @Flag ,@Id,@Name,@SubCatId", pflag, pId, pName, pSubCatId).ToList();
        }
    }
}
