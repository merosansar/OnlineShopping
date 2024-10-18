using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using OnlineShopping.Web.Services.IService;

namespace OnlineShopping.Web.Services.Service
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly EshopContext _context;
        public SubCategoryService(EshopContext context)
        {
            _context = context;            
        }
       
      

        public List<ResponseCode> AddSubCategoryAsync(string flag, int Id, int? CatId, string Name)
        {
            var pflag = new SqlParameter("@Flag", flag);
            var pId = new SqlParameter("@Id", Id);
            var pCatId = new SqlParameter("@Name", Name);
            var pName = new SqlParameter("@CatId", CatId);
            return _context.ResponseCodes.FromSqlRaw("EXECUTE Proc_SubCategory @Flag ,@Id,@Name,@CatId", pflag, pId, pName, pCatId).ToList();
        }

        public List<ResponseCode> DeleteSubCategory(string flag, int? Id, int? CatId, string Name)
        {
            var pFlag = new SqlParameter("@Flag", flag ?? (object)DBNull.Value);
            var pId = new SqlParameter("@Id", Id.HasValue ? (object)Id.Value : DBNull.Value);
            var pName = new SqlParameter("@Name", Name ?? (object)DBNull.Value);
            var pCatId = new SqlParameter("@CatId", CatId.HasValue ? (object)CatId.Value : DBNull.Value);
            return _context.ResponseCodes
              .FromSqlRaw("EXECUTE Proc_SubCategory @Flag, @Id, @Name, @CatId", pFlag, pId, pName, pCatId)
              .ToList();
        }

        public List<SubCategory> GetSubCatList(string flag, string Name, int? Id = null, int? CatId = null)
        {
            // Create SqlParameter instances for each parameter, replacing nulls with DBNull.Value
            var pFlag = new SqlParameter("@Flag", flag ?? (object)DBNull.Value);
            var pId = new SqlParameter("@Id", Id.HasValue ? (object)Id.Value : DBNull.Value);
            var pName = new SqlParameter("@Name", Name ?? (object)DBNull.Value);
            var pCatId = new SqlParameter("@CatId", CatId.HasValue ? (object)CatId.Value : DBNull.Value);
           
            // Execute the stored procedure with the parameters
            return _context.SubCatList
                .FromSqlRaw("EXECUTE Proc_SubCategory @Flag, @Id, @Name, @CatId", pFlag, pId, pName, pCatId)
                .ToList();
        }

        public List<ResponseCode> UpdateSubCategory(string flag, int? Id, int? CatId, string Name)
        {
            var pFlag = new SqlParameter("@Flag", flag ?? (object)DBNull.Value);
            var pId = new SqlParameter("@Id", Id.HasValue ? (object)Id.Value : DBNull.Value);
            var pName = new SqlParameter("@Name", Name ?? (object)DBNull.Value);
            var pCatId = new SqlParameter("@CatId", CatId.HasValue ? (object)CatId.Value : DBNull.Value);
            return _context.ResponseCodes
              .FromSqlRaw("EXECUTE Proc_SubCategory @Flag, @Id, @Name, @CatId", pFlag, pId, pName, pCatId)
              .ToList();
        }
    }
}
