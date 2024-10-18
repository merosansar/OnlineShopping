using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblWishlistItem
{
    public int Id { get; set; }

    public int WishlistId { get; set; }

    public int ProductId { get; set; }

    public DateTime? AddedDate { get; set; }

    public virtual TblProduct Product { get; set; } = null!;

    public virtual TblWishlist Wishlist { get; set; } = null!;
}
