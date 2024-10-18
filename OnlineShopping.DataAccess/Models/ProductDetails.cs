using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.DataAccess.Models
{
    public class ProductDetails
    {

        public int Id { get; set; }
        public int? ProductId { get; set; }
        [Display(Name = "Detail Description")]
        public string? Description { get; set; }       
        public string? Specifications { get; set; }     

        public int? Brand { get; set; }
        public string? ProductModel { get; set; }
        public string? Warranty { get; set; }
        public string? Material { get; set; }
        public string? Color { get; set; }
        public string? Dimensions { get; set; }
        public decimal? Weight { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public decimal? SpecialPrice { get; set; }

        public DateTime? PromotionStartDate { get; set; }

        public DateTime? PromotionEndDate { get; set; }
        public List<ProductDetails>? ProductDetailsList { get; set; }
        public List<SelectListItem>? BrandList { get; set; }
        public List<SelectListItem>? ColorList { get; set; }




    }
}
