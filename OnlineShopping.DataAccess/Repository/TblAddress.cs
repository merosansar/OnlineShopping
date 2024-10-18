using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblAddress
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int AtypeId { get; set; }

    public string Country { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Zone { get; set; } = null!;

    public string District { get; set; } = null!;

    public virtual TblAddressType Atype { get; set; } = null!;
}
