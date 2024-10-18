using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblCart
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int CartStatusId { get; set; }

    public virtual TblCartStatus CartStatus { get; set; } = null!;

    public virtual ICollection<TblCartItem> TblCartItems { get; set; } = new List<TblCartItem>();

    public virtual TblUser User { get; set; } = null!;
}
