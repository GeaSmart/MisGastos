using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MisGastos.Helpers;
using MisGastos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisGastos.Controllers
{
    public class GastosController : Controller
    {
        private readonly ApplicationDbContext context;

        public GastosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var gastos = await context.Gastos.ToListAsync();
            return View(gastos);
        }

        [NoDirectAccess]
        [HttpGet]
        public async Task<ActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Gasto() { Fecha = DateTime.Now });

            var gasto = await context.Gastos.FirstOrDefaultAsync(x => x.Id == id);
            if (gasto == null)
                return NotFound();

            return View(gasto);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(int id, [FromForm] Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                //insert
                if (id == 0)
                {                    
                    context.Gastos.Add(gasto);
                    await context.SaveChangesAsync();
                }
                //update
                else
                {
                    context.Gastos.Update(gasto);
                    await context.SaveChangesAsync();
                }
                return Json(new { isValid = true, html = RenderRazor.RenderRazorViewToString(this, "_VerTodos", context.Gastos.ToList()) });
            }
            return Json(new { isValid = false, html = RenderRazor.RenderRazorViewToString(this, "AddOrEdit", gasto) });
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var gasto = await context.Gastos.FirstOrDefaultAsync(x => x.Id == id);
            if (gasto == null)
                return NotFound();

            context.Gastos.Remove(gasto);
            await context.SaveChangesAsync();
            return Json(new { html = RenderRazor.RenderRazorViewToString(this, "_VerTodos", context.Gastos.ToList()) });
        }
    }
}
