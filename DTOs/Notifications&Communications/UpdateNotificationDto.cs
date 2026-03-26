using System.ComponentModel.DataAnnotations;

namespace PropManageX.DTOs.Notifications_Communications
{
	public class UpdateNotificationDto
	{
		[Required]
		public string Status { get; set; }
	}
}
