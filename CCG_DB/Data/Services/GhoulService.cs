using CCG_DB.Data.ViewModels;
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

        public async Task AddAsync(GhoulViewModel ghoulvm)
        {
            Ghoul ghoul = new Ghoul { Name = ghoulvm.Name, Description = ghoulvm.Description, Rank = ghoulvm.Rank };

            if (ghoulvm.Photo != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(ghoulvm.Photo.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)ghoulvm.Photo.Length);
                }
                // установка массива байтов
                ghoul.Photo = imageData;
            }

            await _context.Ghouls.AddAsync(ghoul);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ghoul = await _context.Ghouls.FirstOrDefaultAsync(n=>n.Id==id);
            _context.Ghouls.Remove(ghoul);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ghoul>> GetAllAysnc()=> await _context.Ghouls.ToListAsync();
           
      

        public async Task<Ghoul> GetByIdAsync(int id)=> await _context.Ghouls.FirstOrDefaultAsync(n => n.Id == id);
        

        public async Task UpdateAsync(GhoulViewModel ghoulvm, int id)
        {
            var ghoul = await GetByIdAsync(id);

            if (ghoulvm.Photo != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(ghoulvm.Photo.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)ghoulvm.Photo.Length);
                }
                // установка массива байтов
                ghoul.Photo = imageData;
            }
            _context.Ghouls.Update(ghoul);
            await _context.SaveChangesAsync();
        }
    }
}
