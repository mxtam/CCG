using CCG_DB.Models;

namespace CCG_DB.Data.Services
{
    public interface IGhoulService
    {
        Task<IEnumerable<Ghoul>> GetAllAysnc();
        Task<Ghoul> GetByIdAsync(int id);
        Task AddAsync(Ghoul ghoul);
        Task UpdateAsync(Ghoul ghoul);
        Task DeleteAsync(int id);
    }
}
