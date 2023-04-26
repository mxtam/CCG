using CCG_DB.Data.ViewModels;
using CCG_DB.Models;

namespace CCG_DB.Data.Services
{
    public interface IGhoulService
    {
        Task<IEnumerable<Ghoul>> GetAllAysnc();
        Task<Ghoul> GetByIdAsync(int id);
        Task AddAsync(GhoulViewModel ghoulvm);
        Task UpdateAsync(GhoulViewModel ghoulvm, int id);
        Task DeleteAsync(int id);
    }
}
