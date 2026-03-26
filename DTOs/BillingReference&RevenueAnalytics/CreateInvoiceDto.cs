using System.ComponentModel.DataAnnotations;

namespace PropManageX.DTOs.BillingReference_RevenueAnalytics
{
	public class CreateInvoiceDto
	{
		[Required]
		public int ContractID { get; set; }

		[Required]
		public string Period { get; set; }

		[Required]
		public decimal Amount { get; set; }

		[Required]
		public DateTime DueDate { get; set; }

	}
}
