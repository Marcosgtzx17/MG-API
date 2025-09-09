using Microsoft.EntityFrameworkCore;
using PracticaAPI.Entidades;
using PracticaAPI.Interfaces;

namespace PracticaAPI.Repositorios
{
    public class CategoriaMGRepository : ICategoriaMGRepository
    {
        private readonly appDBContext _context;

        public CategoriaMGRepository(appDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoriaMG>> GetAllAsync()
        {
            return await _context.CategoriasMG.ToListAsync();
        }

        public async Task<CategoriaMG?> GetByIdAsync(int id)
        {
            return await _context.CategoriasMG.FindAsync(id);
        }

        public async Task<CategoriaMG> AddAsync(CategoriaMG categoria)
        {
            _context.CategoriasMG.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<CategoriaMG> UpdateAsync(CategoriaMG categoria)
        {
            _context.CategoriasMG.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task DeleteAsync(int id)
        {
            var categoria = await _context.CategoriasMG.FindAsync(id);
            if (categoria != null)
            {
                _context.CategoriasMG.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}
