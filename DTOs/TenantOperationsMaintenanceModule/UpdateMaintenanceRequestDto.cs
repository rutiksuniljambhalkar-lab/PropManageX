using System.ComponentModel.DataAnnotations;

namespace PropManageX.DTOs.TenantOperationsMaintenanceModule
{
	public class UpdateMaintenanceRequestDto
	{
		[Required]
		public string Status { get; set; }

	}
}
