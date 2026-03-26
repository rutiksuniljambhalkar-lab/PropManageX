namespace PropManageX.DTOs.Notifications_Communications
{
	public class NotificationDto
	{
		public int NotificationID { get; set; }

		public int UserID { get; set; }

		public string Message { get; set; }

		public string Category { get; set; }

		public string Status { get; set; }

		public DateTime CreatedDate { get; set; }

	}
}
