using System.ComponentModel.DataAnnotations;

namespace PropManageX.DTOs.TenantOperationsMaintenanceModule
{
	public class CreateVendorAssignmentDto
	{
		[Required]
		public int RequestID { get; set; }

		[Required]
		public string VendorName { get; set; }

	}
}
