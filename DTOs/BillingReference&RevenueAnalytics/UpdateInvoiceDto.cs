using System.ComponentModel.DataAnnotations;

namespace PropManageX.DTOs.BillingReference_RevenueAnalytics
{
	public class UpdateInvoiceDto
	{
		[Required]
		public string Status { get; set; }

	}
}
