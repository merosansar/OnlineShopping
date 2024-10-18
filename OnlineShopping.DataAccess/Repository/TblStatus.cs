using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TblDeliveryPartner> TblDeliveryPartners { get; set; } = new List<TblDeliveryPartner>();

    public virtual ICollection<TblSeller> TblSellers { get; set; } = new List<TblSeller>();

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}
