using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblUserProfile
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Bio { get; set; }

    public string? WebSiteUrl { get; set; }

    public string? SocialLink { get; set; }

    public virtual TblUser User { get; set; } = null!;
}
