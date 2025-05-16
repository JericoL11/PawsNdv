using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paws.Application.DTOs;
using Paws.Application.Interfaces;

namespace PawsNdv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnersController( IOwnerService ownerService)
        {
            this._ownerService = ownerService;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<OwnerDisplayDto>>> GetOwnerList(string? search, int pageNo, int pageSize)
        {
            var owners = await _ownerService.GetAllAsync(search,pageNo,pageSize);

            return Ok(owners);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetOwnerById(int id)
        {
            var ownerProfile = await _ownerService.GetByIdAsync(id);

            if (ownerProfile == null)
            {
                return NotFound(new { message = $"Owner with ID {id} not found." });
            }

            return Ok(ownerProfile);

        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] OwnerCreateDto ownerCreateDto)
        {   
            if (ownerCreateDto == null)
            {
                return BadRequest("Invalid Data");
            }
            
            var createOwner = await _ownerService.CreateOwnerAsync(ownerCreateDto);

            return CreatedAtAction(nameof(GetOwnerList), createOwner); //update the table
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<OwnerUpdateDto>> Edit(int id, OwnerUpdateDto ownerUpdateDto)
        {
            if (ownerUpdateDto == null)
                return BadRequest("Owner data is required");

            var updateOwner = await _ownerService.UpdateOwnerAsync(id, ownerUpdateDto);

            if (updateOwner == null)
            {
                return NotFound($"Owner with {id} not found.");
            }

            return Ok(updateOwner);
        }
    }
}
