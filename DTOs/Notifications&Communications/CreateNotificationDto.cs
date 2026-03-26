using System.ComponentModel.DataAnnotations;

namespace PropManageX.DTOs.Notifications_Communications
{
	public class CreateNotificationDto
	{
		[Required]
		public int UserID { get; set; }

		[Required]
		public string Message { get; set; }

		[Required]
		public string Category { get; set; }
	}
}
