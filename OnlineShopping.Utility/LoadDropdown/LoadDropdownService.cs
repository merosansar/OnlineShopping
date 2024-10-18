using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using System.Data;

namespace OnlineShopping.Utility.LoadDropdown
{
    public class LoadDropdownService : ILoadDropdownService
    {
        private readonly EshopContext _context;

        public LoadDropdownService(EshopContext context)
        {
            _context = context;
        }
        public  List<LoadDropdownModel> GetDropdownData(string Param, string Filter)
        {

           
            SqlParameter pParam = new SqlParameter("@Param", Param);
            SqlParameter pFilter = new SqlParameter("@Filter", Filter);
            return _context.LoadDropdownModels.FromSqlRaw("EXECUTE Proc_LoadDropdown @Param ,@Filter", pParam, pFilter).ToList();

        }

        


    }
}
