using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;

namespace OnlineShopping.Utility.LoadDropdown
{
    public interface ILoadDropdownService
    {
        List<LoadDropdownModel> GetDropdownData(String Param, String Filter);
    }
}
