using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblProduct
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int SubCatId { get; set; }

    public int ItemId { get; set; }

    public int? SellerId { get; set; }

    public virtual TblCategory Category { get; set; } = null!;

    public virtual TblItem Item { get; set; } = null!;

    public virtual TblSeller? Seller { get; set; }

    public virtual TblSubCategory SubCat { get; set; } = null!;

    public virtual ICollection<TblCartItem> TblCartItems { get; set; } = new List<TblCartItem>();

    public virtual ICollection<TblComment> TblComments { get; set; } = new List<TblComment>();

    public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; } = new List<TblOrderDetail>();

    public virtual ICollection<TblProductDetail> TblProductDetails { get; set; } = new List<TblProductDetail>();

    public virtual ICollection<TblWishlistItem> TblWishlistItems { get; set; } = new List<TblWishlistItem>();
}
