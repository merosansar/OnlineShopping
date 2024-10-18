using OnlineShopping.DataAccess.Models;

namespace OnlineShopping.Web.Services.IService
{
    public interface IDashboardService
    {
        List<DashboardModel> GetAll();
    }
}
