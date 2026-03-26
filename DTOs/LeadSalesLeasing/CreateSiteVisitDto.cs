namespace PropManageX.DTOs.LeadSalesLeasing
{
	public class CreateSiteVisitDto
	{
		public int LeadID { get; set; }

		public DateTime VisitDate { get; set; }

		public int AgentID { get; set; }

		public string Notes { get; set; }

	}
}
