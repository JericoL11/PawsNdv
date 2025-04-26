using Paws.Application.DTOs;
using Paws.Application.Helpers;
using PawsNdv.Domain.Enums;

namespace Paws.Application.Interfaces
{
    //dto is for front end
    public interface IOwnerService
    {
        Task<PagedResponse<OwnerDisplayDto>> GetAllAsync(string? search, int pageNo, int pageSize);
        Task<OwnerDisplayDto?> GetByIdAsync(int id);
        Task<OwnerDisplayDto?> CreateOwnerAsync(OwnerCreateDto dto);
        Task<bool> UpdateOwnerAsync(int id, OwnerUpdateDto dto);
        Task<bool> DeleteOwnerAsync(int id);
    }

}
