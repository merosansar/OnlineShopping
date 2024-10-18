using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblNotification
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime NotificationDate { get; set; }

    public int NotificationStatusId { get; set; }

    public virtual TblNotificationStatus NotificationStatus { get; set; } = null!;

    public virtual TblUser User { get; set; } = null!;
}
