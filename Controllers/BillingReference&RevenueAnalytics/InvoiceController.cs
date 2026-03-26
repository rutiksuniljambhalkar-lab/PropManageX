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
	public class InvoiceController : ControllerBase
	{

		private readonly IInvoiceService _service;

		public InvoiceController(IInvoiceService service)
		{
			_service = service;
		}

		[Authorize(Roles = "Finance Analyst,Admin")]
		[HttpPost]
		public async Task<IActionResult> CreateInvoice(CreateInvoiceDto dto)
		{
			var invoice = await _service.CreateInvoice(dto);
			return Ok(invoice);
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> GetInvoices()
		{
			var invoices = await _service.GetInvoices();
			return Ok(invoices);
		}

		[Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetInvoiceById(int id)
		{
			var invoice = await _service.GetInvoiceById(id);

			if (invoice == null)
				return NotFound("Invoice not found");

			return Ok(invoice);
		}

		[Authorize(Roles = "Finance Analyst,Admin")]
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateInvoiceStatus(int id, UpdateInvoiceDto dto)
		{
			var invoice = await _service.UpdateInvoiceStatus(id, dto);

			if (invoice == null)
				return NotFound("Invoice not found");

			return Ok(invoice);
		}

		[Authorize(Roles = "Finance Analyst,Admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteInvoice(int id)
		{
			var result = await _service.DeleteInvoice(id);

			if (!result)
				return NotFound("Invoice not found");

			return Ok("Invoice deleted successfully");
		}


	}
}
