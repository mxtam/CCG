using Microsoft.AspNetCore.Mvc;
using CCG_DB.Models;
using CCG_DB.Data.Services;
using CCG_DB.Data.ViewModels;
using System;

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
        public async Task<IActionResult> Add(GhoulViewModel ghoulvm)
        {
            
            await _service.AddAsync(ghoulvm);

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
        public async Task<IActionResult> Edit(GhoulViewModel ghoulvm, int id)
        {
            
            await _service.UpdateAsync(ghoulvm,id);
            return RedirectToAction("Index");
        }

    }
}
