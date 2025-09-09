using PracticaAPI.DTOs.CategoriaDTOs;

namespace PracticaAPI.Interfaces
{
    public interface ICategoriaMGService
    {
        Task<IEnumerable<CategoriaMGDto>> GetAllAsync();
        Task<CategoriaMGDto?> GetByIdAsync(int id);
        Task<CategoriaMGDto> CreateAsync(CategoriaMGCreateDto dto);
        Task<CategoriaMGDto?> UpdateAsync(int id, CategoriaMGCreateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
