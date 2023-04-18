using CCG_DB.Models;
using Microsoft.EntityFrameworkCore;

namespace CCG_DB.Data.Services
{
    public class GhoulService : IGhoulService
    {
        private readonly ApplicationContext _context;
        public GhoulService(ApplicationContext context) 
        {
            _context= context;
        }

        public async Task AddAsync(Ghoul ghoul)
        {
            await _context.Ghouls.AddAsync(ghoul);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ghoul = await _context.Ghouls.FirstOrDefaultAsync(n=>n.Id==id);
            _context.Ghouls.Remove(ghoul);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ghoul>> GetAllAysnc()
        {
            var allGhouls = await _context.Ghouls.ToListAsync();
            return allGhouls;
        }

        public async Task<Ghoul> GetByIdAsync(int id)=> await _context.Ghouls.FirstOrDefaultAsync(n => n.Id == id);
        

        public async Task UpdateAsync(Ghoul ghoul)
        {
            _context.Ghouls.Update(ghoul);
            await _context.SaveChangesAsync();
        }
    }
}
