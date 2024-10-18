using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblNotificationStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<TblNotification> TblNotifications { get; set; } = new List<TblNotification>();
}
