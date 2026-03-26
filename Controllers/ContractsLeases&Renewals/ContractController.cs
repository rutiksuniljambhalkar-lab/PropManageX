using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropManageX.DTOs.ContractsLeases_Renewals;
using PropManageX.Services.ContractsLeases_Renewals;

namespace PropManageX.Controllers
{
	[Authorize(Roles = "Agent,Property Manager")]
	[Route("api/[controller]")]
	[ApiController]
	public class ContractController : ControllerBase
	{

		private readonly IContractService _contractService;

		public ContractController(IContractService contractService)
		{
			_contractService = contractService;
		}

		[Authorize(Roles = "Agent,Admin")]
		[HttpGet]
		public async Task<IActionResult> GetAllContracts()
		{
			var contracts = await _contractService.GetAllContracts();
			return Ok(contracts);
		}

		[Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetContractById(int id)
		{
			var contract = await _contractService.GetContractById(id);

			if (contract == null)
				return NotFound("Contract not found");

			return Ok(contract);
		}

		[Authorize(Roles = "Agent,Admin")]
		[HttpPost]
		public async Task<IActionResult> CreateContract(CreateContractDto createdto)
		{
			var contract = await _contractService.CreateContract(createdto);
			if (contract == null)
			{
				return BadRequest($"Contract for {createdto.DealID} alredy exisit");
			}
			return Ok(contract);
		}

		[Authorize(Roles = "Agent,Admin")]
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateContract(int id, UpdateContractDto dto)
		{
			var contract = await _contractService.UpdateContract(id, dto);

			if (contract == null)
				return NotFound("Contract not found");

			return Ok(contract);
		}

		[Authorize(Roles = "Admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteContract(int id)
		{
			var result = await _contractService.DeleteContract(id);

			if (!result)
				return NotFound("Contract not found");

			return Ok("Contract deleted successfully");
		}



	}
}
