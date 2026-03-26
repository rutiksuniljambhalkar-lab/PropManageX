using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropManageX.DTOs.PropertyDTOs.AmenityDTOs;
using PropManageX.Services.PropertyListingInventoryManagement;

namespace PropManageX.Controllers.PropertyListingInventoryManagement
{
	[Authorize(Roles = "Admin,Property Manager")]
	[Route("api/[controller]")]
	[ApiController]
	public class AmenityController : ControllerBase
	{
		private readonly IAmenityService _amenityService;

		public AmenityController(IAmenityService amenityService)
		{
			_amenityService = amenityService;
		}

		// Get all amenities
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> GetAllAmenities()
		{
			var amenities = await _amenityService.GetAllAmenities();
			return Ok(amenities);
		}

		// Get amenity by ID
		[Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAmenityById(int id)
		{
			var amenity = await _amenityService.GetAmenityById(id);

			if (amenity == null)
				return NotFound("Amenity not found");

			return Ok(amenity);
		}

		// Create amenity (Admin only)
		[Authorize(Roles = "Admin")]
		[HttpPost]
		public async Task<IActionResult> CreateAmenity(CreateAmenityDto dto)
		{
			var amenity = await _amenityService.CreateAmenity(dto);
			return Ok(amenity);
		}

		// Update amenity (Admin only)
		[Authorize(Roles = "Admin")]
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAmenity(int id, UpdateAmenityDto dto)
		{
			var amenity = await _amenityService.UpdateAmenity(id, dto);

			if (amenity == null)
				return NotFound("Amenity not found");

			return Ok(amenity);
		}

		// Delete amenity (Admin only)
		[Authorize(Roles = "Admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAmenity(int id)
		{
			var result = await _amenityService.DeleteAmenity(id);

			if (!result)
				return NotFound("Amenity not found");

			return Ok("Amenity deleted successfully");
		}

	}
}