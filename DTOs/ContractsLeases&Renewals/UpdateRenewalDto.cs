using System.ComponentModel.DataAnnotations;

namespace PropManageX.DTOs.ContractsLeases_Renewals
{
	public class UpdateRenewalDto
	{


		[Required]
		[Range(1, double.MaxValue)]
		public decimal ProposedValue { get; set; }

		[Required]
		public DateTime ProposedEndDate { get; set; }

		[Required]
		[RegularExpression("Offered|Accepted|Declined", ErrorMessage = "Invalid status")]
		public string Status { get; set; }

	}
}
