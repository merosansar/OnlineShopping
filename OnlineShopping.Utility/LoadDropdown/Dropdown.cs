using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Utility.LoadDropdown
{
    public class Dropdown
    {
        private readonly EshopContext _context;

        public Dropdown(EshopContext context)
        {
            _context = context;
        }
        public  List<SelectListItem> GetDropDownList(string Parameter, string Filter)
        {
            SqlParameter pParam = new SqlParameter("@Param", Parameter);
            SqlParameter pFilter = new SqlParameter("@Filter", Filter);
            var dropList = _context.LoadDropdownModels.FromSqlRaw("EXECUTE Proc_LoadDropdown @Param ,@Filter", pParam, pFilter).ToList();
            var list = new List<SelectListItem>();          
            list.Add(new SelectListItem() { Text = "--Select--", Value = "", Selected = true });
            if(dropList != null)
            { 
            foreach (var item in dropList)
            {
                list.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString(), Selected = false });
            }
                return list;
            }
            else 
                return list;
           
        }

    }
}
