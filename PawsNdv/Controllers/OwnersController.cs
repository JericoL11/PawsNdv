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
    }
}
