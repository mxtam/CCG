using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CCG_DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Xml.Linq;
using CCG_DB.Data;
using CCG_DB.Data.Services;

namespace CCG_DB.Controllers
{
    public class GhoulController : Controller
    {
        private readonly IGhoulService _service;
        
        public GhoulController(IGhoulService service)
        {
            _service= service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAysnc());

        }

        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Ghoul ghoul)
        {

            await _service.AddAsync(ghoul);

            return RedirectToAction("Index");
        }

        public IActionResult Delete()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            await _service.DeleteAsync(id);

            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Details(int id)
        {
            var ghoul = await _service.GetByIdAsync(id);
            if(ghoul==null) return NotFound();
            return View(ghoul);

        }

        public async Task<IActionResult> Edit(int id)
        {
            var ghoul = await _service.GetByIdAsync(id);
            if (ghoul == null) return NotFound();
            return View(ghoul);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Ghoul ghoul)
        {
            await _service.UpdateAsync(ghoul);
            return RedirectToAction("Index");
        }

    }
}
