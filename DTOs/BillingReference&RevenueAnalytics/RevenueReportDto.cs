namespace PropManageX.DTOs.BillingReference_RevenueAnalytics
{
	public class RevenueReportDto
	{
		public int ReportID { get; set; }

		public string Scope { get; set; }

		public string Metrics { get; set; }

		public DateTime GeneratedDate { get; set; }

	}
}
