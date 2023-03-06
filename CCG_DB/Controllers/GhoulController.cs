using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CCG_DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Xml.Linq;

namespace CCG_DB.Controllers
{
    public class GhoulController : Controller
    {
        ApplicationContext db;

        string currentPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "Ghoul", "InfoPage");
        
        public GhoulController(ApplicationContext db)
        {
            this.db = db; 
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await db.Ghouls.ToListAsync());

        }
        
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Ghoul ghoul)
        { 
         
            db.Ghouls.Add(ghoul);

            string path = Path.Combine(currentPath,$"{ghoul.Name}-Info.cshtml");

            CustomMethods.CreateInfoPage(path, ghoul.Name, ghoul.Rank, ghoul.Description, ghoul.ImageUrl); ;

            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Delete()
        {
   
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
          
            if (id != null)
            {
                Ghoul? ghoul = await db.Ghouls.FirstOrDefaultAsync(p => p.Id == id);
                if (ghoul != null)
                {
                    db.Ghouls.Remove(ghoul);
                    string path = Path.Combine(currentPath, $"{ghoul.Name}-Info.cshtml");

                    CustomMethods.DeleteInfoPage(path);

                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            
            return NotFound();
        }

        public async Task<IActionResult> Info(int? id) 
        {
            Ghoul? ghoul = await db.Ghouls.FirstOrDefaultAsync(p => p.Id == id);
            if (ghoul != null)
            {
                return View($"InfoPage/{ghoul.Name}-Info");
            
            }
            return BadRequest();    

        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Ghoul? ghoul = await db.Ghouls.FirstOrDefaultAsync(p => p.Id == id);
                if (ghoul != null) return View(ghoul);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Ghoul ghoul)
        {
           
            db.Ghouls.Update(ghoul);

            string path = Path.Combine(currentPath, $"{ghoul.Name}-Info.cshtml");

            CustomMethods.CreateInfoPage(path, ghoul.Name, ghoul.Rank, ghoul.Description, ghoul.ImageUrl);

            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
