using PracticaAPI.DTOs.CategoriaDTOs;
using PracticaAPI.Entidades;
using PracticaAPI.Interfaces;

namespace PracticaAPI.Services
{
    public class CategoriaMGService : ICategoriaMGService
    {
        private readonly ICategoriaMGRepository _repo;

        public CategoriaMGService(ICategoriaMGRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CategoriaMGDto>> GetAllAsync()
        {
            var categorias = await _repo.GetAllAsync();
            return categorias.Select(c => new CategoriaMGDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion
            });
        }

        public async Task<CategoriaMGDto?> GetByIdAsync(int id)
        {
            var c = await _repo.GetByIdAsync(id);
            if (c == null) return null;
            return new CategoriaMGDto { Id = c.Id, Nombre = c.Nombre, Descripcion = c.Descripcion };
        }

        public async Task<CategoriaMGDto> CreateAsync(CategoriaMGCreateDto dto)
        {
            var c = new CategoriaMG { Nombre = dto.Nombre, Descripcion = dto.Descripcion };
            var created = await _repo.AddAsync(c);
            return new CategoriaMGDto { Id = created.Id, Nombre = created.Nombre, Descripcion = created.Descripcion };
        }

        public async Task<CategoriaMGDto?> UpdateAsync(int id, CategoriaMGCreateDto dto)
        {
            var c = await _repo.GetByIdAsync(id);
            if (c == null) return null;
            c.Nombre = dto.Nombre;
            c.Descripcion = dto.Descripcion;
            var updated = await _repo.UpdateAsync(c);
            return new CategoriaMGDto { Id = updated.Id, Nombre = updated.Nombre, Descripcion = updated.Descripcion };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var c = await _repo.GetByIdAsync(id);
            if (c == null) return false;
            await _repo.DeleteAsync(id);
            return true;
        }
    }
}
