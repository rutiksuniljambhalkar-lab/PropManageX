using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropManageX.DTOs.Documents_ComplianceManagement;
using PropManageX.Services.Documents_ComplianceManagement;

namespace PropManageX.Controllers.NewFolder
{
	[Authorize(Roles = "Admin,Property Manager,Agent")]
	[Route("api/[controller]")]
	[ApiController]
	public class DocumentController : ControllerBase
	{
		private readonly IDocumentService _service;

		public DocumentController(IDocumentService service)
		{
			_service = service;
		}

		// Upload document
		[Authorize]
		[HttpPost]
		public async Task<IActionResult> UploadDocument([FromForm] CreateDocumentDto dto)
		{
			var result = await _service.UploadDocument(dto);
			return Ok(result);
		}

		// Get all documents
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> GetAllDocuments()
		{
			var docs = await _service.GetAllDocuments();
			return Ok(docs);
		}

		// Get documents by entity (IMPORTANT)
		[Authorize]
		[HttpGet("entity")]
		public async Task<IActionResult> GetByEntity(string entityType, int entityId)
		{
			var docs = await _service.GetDocumentsByEntity(entityType, entityId);
			return Ok(docs);
		}

		// Get by ID
		[Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var doc = await _service.GetDocumentById(id);

			if (doc == null)
				return NotFound("Document not found");

			return Ok(doc);
		}

		// Delete (Admin only)
		[Authorize(Roles = "Admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _service.DeleteDocument(id);

			if (!result)
				return NotFound("Document not found");

			return Ok("Deleted successfully");
		}

	}
}
