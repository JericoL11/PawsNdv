using Paws.Application.DTOs;
using PawsNdv.Domain.Enums;

namespace Paws.Application.Interfaces
{
    //dto is for front end
    public interface IOwnerService
    {
        Task<IEnumerable<OwnerDisplayDto>> GetAllOwnerAsync();
        Task<OwnerDisplayDto?> GetByIdAsync(int id);
        Task<OwnerDisplayDto?> CreateOwnerAsync(OwnerCreateDto dto);
        Task<bool> UpdateOwnerAsync(int id, OwnerUpdateDto dto);
        Task<bool> DeleteOwnerAsync(int id);
    }

}
