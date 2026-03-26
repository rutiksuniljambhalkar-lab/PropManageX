using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropManageX.DTOs.BillingReference_RevenueAnalytics;
using PropManageX.Services.BillingReference_RevenueAnalytics;

namespace PropManageX.Controllers.NewFolder
{
	//[Authorize(Roles = "Finance Analyst,Admin")]
	[Route("api/[controller]")]
	[ApiController]
	public class RevenueReportController : ControllerBase
	{

		private readonly IRevenueReportService _service;

		public RevenueReportController(IRevenueReportService service)
		{
			_service = service;
		}

		[Authorize(Roles = "Finance Analyst,Admin")]
		[HttpPost]
		public async Task<IActionResult> GenerateReport(CreateRevenueReportDto dto)
		{
			var report = await _service.GenerateReport(dto);
			return Ok(report);
		}

		[Authorize(Roles = "Finance Analyst,Admin")]
		[HttpGet]
		public async Task<IActionResult> GetReports()
		{
			var reports = await _service.GetReports();
			return Ok(reports);
		}

		[Authorize(Roles = "Finance Analyst,Admin")]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetReportById(int id)
		{
			var report = await _service.GetReportById(id);

			if (report == null)
				return NotFound("Report not found");

			return Ok(report);
		}

		[Authorize(Roles = "Finance Analyst,Admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteReport(int id)
		{
			var result = await _service.DeleteReport(id);

			if (!result)
				return NotFound("Report not found");

			return Ok("Report deleted successfully");
		}



	}
}
