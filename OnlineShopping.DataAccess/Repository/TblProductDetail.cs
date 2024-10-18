using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblProductDetail
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string? Description { get; set; }

    public string? Specifications { get; set; }

    public string? Brand { get; set; }

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

    public string? SellerSku { get; set; }

    public decimal? Length { get; set; }

    public decimal? Width { get; set; }

    public decimal? Height { get; set; }

    public virtual TblProduct Product { get; set; } = null!;
}
