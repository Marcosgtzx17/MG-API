using PracticaAPI.Entidades;

namespace PracticaAPI.Interfaces
{
    public interface ICategoriaMGRepository
    {
        Task<IEnumerable<CategoriaMG>> GetAllAsync();
        Task<CategoriaMG?> GetByIdAsync(int id);
        Task<CategoriaMG> AddAsync(CategoriaMG categoria);
        Task<CategoriaMG> UpdateAsync(CategoriaMG categoria);
        Task DeleteAsync(int id);
    }
}
