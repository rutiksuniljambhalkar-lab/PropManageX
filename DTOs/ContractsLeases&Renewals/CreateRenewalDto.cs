using System.ComponentModel.DataAnnotations;

namespace PropManageX.DTOs.ContractsLeases_Renewals
{
	public class CreateRenewalDto
	{

		[Required]
		public int ContractID { get; set; }

		[Required]
		[Range(1, double.MaxValue, ErrorMessage = "Proposed value must be greater than 0")]
		public decimal ProposedValue { get; set; }

		[Required]
		public DateTime ProposedEndDate { get; set; }


	}
}
