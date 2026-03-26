using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropManageX.DTOs.PropertyDTOs.UnitsDTOs;
using PropManageX.Services.PropertyListingInventoryManagement;

namespace PropManageX.Controllers.PropertyListingInventoryManagement
{

	//[Authorize(Roles = "Admin,Property Manager")]
	[Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        // View all units (Any logged in user)
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUnits()
        {
            var units = await _unitService.GetAllUnits();
            return Ok(units);
        }

       
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUnitById(int id)
        {
            var unit = await _unitService.GetUnitById(id);

            if (unit == null)
                return NotFound("Unit not found");

            return Ok(unit);
        }

		
		[Authorize(Roles = "Admin,Property Manager")]
		[HttpPost]
        public async Task<IActionResult> CreateUnit(CreateUnitDto dto)
        {
            var unit = await _unitService.CreateUnit(dto);
            if (unit == null)
            {
                return BadRequest("Limit Exceeded for this property");
            }

            return Ok(unit);
        }

		
		[Authorize(Roles = "Admin,Property Manager")]
		[HttpPut("{id}")]
        public async Task<IActionResult> UpdateUnit(int id, UpdateUnitDto dto)
        {
            var unit = await _unitService.UpdateUnit(id, dto);

            if (unit == null)
                return NotFound("Unit not found");

            return Ok(unit);
        }

		
		[Authorize(Roles = "Admin,Property Manager")]
		[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            var result = await _unitService.DeleteUnit(id);

            if (!result)
                return NotFound("Unit not found");

            return Ok("Unit deleted successfully");
        }

    }
}