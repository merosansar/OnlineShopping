using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblWishlist
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<TblWishlistItem> TblWishlistItems { get; set; } = new List<TblWishlistItem>();

    public virtual TblUser User { get; set; } = null!;
}
