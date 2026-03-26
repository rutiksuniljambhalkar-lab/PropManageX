namespace PropManageX.DTOs.LeadSalesLeasing
{
	public class CreateDealDto
	{

		public int LeadID { get; set; }

		public int UnitID { get; set; }

		public string DealType { get; set; } //(Sale/Lease) 

		public decimal AgreedValue { get; set; }


	}
}
