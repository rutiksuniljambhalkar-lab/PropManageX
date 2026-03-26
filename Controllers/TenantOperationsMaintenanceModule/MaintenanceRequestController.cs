using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropManageX.DTOs.TenantOperationsMaintenanceModule;
using PropManageX.Services.TenantOperationsMaintenanceModule;

namespace PropManageX.Controllers.TenantOperationsMaintenanceModule
{
	//[Authorize(Roles = "Finance Analyst,Admin")]
	[Route("api/[controller]")]
	[ApiController]
	public class MaintenanceRequestController : ControllerBase
	{
		private readonly IMaintenanceRequestService _service;

		public MaintenanceRequestController(IMaintenanceRequestService service)
		{
			_service = service;
		}

		[Authorize(Roles = "Tenant")]
		[HttpPost]
		public async Task<IActionResult> CreateRequest(CreateMaintenanceRequestDto dto)
		{
			var result = await _service.CreateRequest(dto);
			return Ok(result);
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> GetAllRequests()
		{
			var requests = await _service.GetAllRequests();
			return Ok(requests);
		}

		[Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetRequestById(int id)
		{
			var request = await _service.GetRequestById(id);

			if (request == null)
				return NotFound("Request not found");

			return Ok(request);
		}

		[Authorize(Roles = "Property Manager")]
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateStatus(int id, UpdateMaintenanceRequestDto dto)
		{
			var request = await _service.UpdateRequestStatus(id, dto);

			if (request == null)
				return NotFound("Request not found");

			return Ok(request);
		}

		[Authorize(Roles = "Property Manager")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteRequest(int id)
		{
			var result = await _service.DeleteRequest(id);

			if (!result)
				return NotFound("Request not found");

			return Ok("Request deleted successfully");
		}

	}
}
