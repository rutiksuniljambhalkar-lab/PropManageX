using System.ComponentModel.DataAnnotations;

namespace PropManageX.DTOs.BillingReference_RevenueAnalytics
{
	public class CreateRevenueReportDto
	{
		[Required]
		public string Scope { get; set; }

		[Required]
		public string Metrics { get; set; }

	}
}
