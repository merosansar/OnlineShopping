using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblCouponUsage
{
    public int Id { get; set; }

    public int CouponId { get; set; }

    public int UserId { get; set; }

    public int OrderId { get; set; }

    public DateTime? UsageDate { get; set; }

    public virtual TblCoupon Coupon { get; set; } = null!;

    public virtual TblOrder Order { get; set; } = null!;

    public virtual TblUser User { get; set; } = null!;
}
