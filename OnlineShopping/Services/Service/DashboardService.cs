using Microsoft.EntityFrameworkCore;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using OnlineShopping.Web.Services.IService;

namespace OnlineShopping.Web.Services.Service
{
    public class DashboardService(EshopContext context) : IDashboardService
    {
        private readonly EshopContext _context = context;
        public List<DashboardModel> GetAll()
        {
            return _context.DashboardModels.FromSqlRaw("EXECUTE Proc_Dashboard ").ToList();
        }
    }
}
