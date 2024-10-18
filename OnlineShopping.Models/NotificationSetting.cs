using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Models
{
    public class NotificationSetting
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("NotificationType")]
        public int TypeId { get; set; }

        public bool IsEnabled { get; set; } = true;
    }
}
