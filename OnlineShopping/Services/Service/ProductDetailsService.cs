using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using OnlineShopping.Web.Services.IService;

namespace OnlineShopping.Web.Services.Service
{
    public class ProductDetailsService(EshopContext context) : IProductDetailsService
    {
        private readonly EshopContext _context = context;

        public List<ResponseCode> ChangeProductDetails(string flag, int Id, int ProductId, string Description, string Specifications, int Brand, string ProductModel, string Warranty, string Material, string Color, string Dimensions, decimal Weight, DateTime? PromotionStartDate, DateTime? PromotionEndDate, decimal? SpecialPrice)
        {
            var pflag = new SqlParameter("@Flag", flag);
            var pId = new SqlParameter("@Id", Id);
            var pProductId = new SqlParameter("@ProductId", ProductId);
            var pDescription = new SqlParameter("@Description", Description);
            var pSpecifications = new SqlParameter("@Specifications", Specifications);
            var pBrand = new SqlParameter("@Brand", Brand);
            var pProductModel = new SqlParameter("@ProductModel", ProductModel);
            var pWarranty = new SqlParameter("@Warranty", Warranty);
            var pMaterial = new SqlParameter("@Material", Material);
            var pColor = new SqlParameter("@Color", Color);
            var pDimensions = new SqlParameter("@Dimensions", Dimensions);
            var pWeight = new SqlParameter("@Weight", Weight);
            var pPromotionStartDate = new SqlParameter("@PromotionStartDate", (object?)PromotionStartDate ?? DBNull.Value);
            var pPromotionEndDate = new SqlParameter("@PromotionEndDate", (object?)PromotionEndDate ?? DBNull.Value);
            var pSpecialPrice = new SqlParameter("@SpecialPrice", (object?)SpecialPrice ?? DBNull.Value);
            return [.. _context.ResponseCodes.FromSqlRaw("EXECUTE Proc_ProductDetails @Flag,@Id,@ProductId,@Description,@Specifications,@Brand,@ProductModel,@Warranty,@Material,@Color,@Dimensions,@Weight,@PromotionStartDate,@PromotionEndDate,@SpecialPrice", pflag, pId, pProductId, pDescription, pSpecifications, pBrand, pProductModel, pWarranty, pMaterial, pColor, pDimensions, pWeight, pPromotionStartDate, pPromotionEndDate, pSpecialPrice)];
        }

       

        public List<ProductDetails> GetProductDetails(string flag, int Id, int ProductId, string Description, string Specifications, int Brand, string ProductModel, string Warranty, string Material, string Color, string Dimensions, decimal Weight, DateTime? PromotionStartDate, DateTime? PromotionEndDate, decimal? SpecialPrice)
        {
            var pflag = new SqlParameter("@Flag", flag);
            var pId = new SqlParameter("@Id", Id);
            var pProductId = new SqlParameter("@ProductId", ProductId);
            var pDescription = new SqlParameter("@Description", Description);
            var pSpecifications = new SqlParameter("@Specifications", Specifications); 
            var pBrand = new SqlParameter("@Brand", Brand);
            var pProductModel = new SqlParameter("@ProductModel", ProductModel);
            var pWarranty = new SqlParameter("@Warranty", Warranty);
            var pMaterial = new SqlParameter("@Material", Material);
            var pColor = new SqlParameter("@Color", Color);
            var pDimensions = new SqlParameter("@Dimensions", Dimensions);
            var pWeight = new SqlParameter("@Weight", Weight);
            var pPromotionStartDate = new SqlParameter("@PromotionStartDate", (object?)PromotionStartDate ?? DBNull.Value);
            var pPromotionEndDate = new SqlParameter("@PromotionEndDate", (object?)PromotionEndDate ?? DBNull.Value);
            var pSpecialPrice = new SqlParameter("@SpecialPrice", (object?)SpecialPrice?? DBNull.Value);
            
            return [.. _context.ProductDetail.FromSqlRaw("EXECUTE Proc_ProductDetails @Flag,@Id,@ProductId,@Description,@Specifications,@Brand,@ProductModel,@Warranty,@Material,@Color,@Dimensions,@Weight,@PromotionStartDate,@PromotionEndDate,@SpecialPrice", pflag, pId, pProductId, pDescription, pSpecifications, pBrand, pProductModel, pWarranty, pMaterial, pColor, pDimensions, pWeight,pPromotionStartDate,pPromotionEndDate, pSpecialPrice)];
        }

       
    }
}
