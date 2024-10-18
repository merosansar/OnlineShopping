using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using System.Collections.Generic;
using OnlineShopping.Web.Services.CategoryService;

using System.Data;

namespace OnlineShopping.Web.Services.Service
{
    public class CategoryService(EshopContext context) : ICategoryService
    {
        private readonly EshopContext _context = context;

        public async Task<ResponseCode> AddCategoryAsync(string flag, int? Id, string Name, string Description)
        {
            var result = new ResponseCode();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Proc_Category";
                command.Parameters.Add(new SqlParameter("@Flag", flag));
                command.Parameters.Add(new SqlParameter("@Id", Id.HasValue ? (object)Id.Value : DBNull.Value));
                command.Parameters.Add(new SqlParameter("@Name", Name ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("@Description", Description ?? (object)DBNull.Value));
                await _context.Database.OpenConnectionAsync();
                using var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    result.Status = reader.GetString(reader.GetOrdinal("Status"));
                    result.Code = reader.GetString(reader.GetOrdinal("Code"));
                    result.Message = reader.GetString(reader.GetOrdinal("Message"));
                }
            }
            return result;

        }

        public List<ResponseCode> DeleteCategory(string flag, int? Id, string Name, string Description)
        {
            var pflag = new SqlParameter("@Flag", flag ?? (object)DBNull.Value);
            var pId = new SqlParameter("@Id", Id.HasValue ? (object)Id.Value : DBNull.Value);
            var pName = new SqlParameter("@Name", Name ?? (object)DBNull.Value);
            var pDescription = new SqlParameter("@Description", Description ?? (object)DBNull.Value);
            return [.. _context.ResponseCodes.FromSqlRaw("EXECUTE Proc_Category @Flag ,@Id,@Name,@Description", pflag, pId, pName, pDescription)];
        }


        public List<TblCategory> GetCategory(string flag, int? Id, string Name, string Description)
        {
            var pflag = new SqlParameter("@Flag", flag ?? (object)DBNull.Value);
            var pId = new SqlParameter("@Id", Id.HasValue ? (object)Id.Value : DBNull.Value);
            var pName = new SqlParameter("@Name", Name ?? (object)DBNull.Value);
            var pDescription = new SqlParameter("@Description", Description ??(object)DBNull.Value);
            return [.. _context.TblCategories.FromSqlRaw("EXECUTE Proc_Category @Flag ,@Id,@Name,@Description", pflag, pId, pName, pDescription)];
        }

        public List<ResponseCode> UpdateCategory(string flag, int? Id, string Name, string Description)
        {
          
            var pflag = new SqlParameter("@Flag", flag ?? (object)DBNull.Value);
            var pId = new SqlParameter("@Id", Id.HasValue ? (object)Id.Value : DBNull.Value);
            var pName = new SqlParameter("@Name", Name ?? (object)DBNull.Value);
            var pDescription = new SqlParameter("@Description", Description ?? (object)DBNull.Value);
            return [.. _context.ResponseCodes.FromSqlRaw("EXECUTE Proc_Category @Flag ,@Id,@Name,@Description", pflag, pId, pName, pDescription)];

          
        }

       
    }
}
