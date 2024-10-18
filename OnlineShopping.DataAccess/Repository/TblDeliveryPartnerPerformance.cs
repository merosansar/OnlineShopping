using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblDeliveryPartnerPerformance
{
    public int Id { get; set; }

    public int PartnerId { get; set; }

    public double? Rating { get; set; }

    public string? Feedback { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual TblDeliveryPartner Partner { get; set; } = null!;
}
