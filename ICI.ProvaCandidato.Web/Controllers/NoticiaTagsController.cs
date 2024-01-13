using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICI.ProvaCandidato.Web.Models;
using UniApi.Context;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class NoticiaTagsController : Controller
    {
        private readonly AppDbContext _context;

        public NoticiaTagsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: NoticiaTags
        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
            var dados = _context.NoticiaTag.Include(x => x.Noticia).Include(x=>x.Tag);
            return View(await dados.ToListAsync());
        }

        // GET: NoticiaTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var noticiaTag = await _context.NoticiaTag
                .Include(x => x.Tag)
                .Include(x => x.Noticia)
                .ThenInclude(x => x.Usuario)
                .FirstOrDefaultAsync(m => m.NoticiaTagId == id);
            
            if (noticiaTag == null)
            {
                return NotFound();
            }

            return View(noticiaTag);
        }

        // GET: NoticiaTags/Create
        public IActionResult Create()
        {
            ViewData["NoticiaId"] = new SelectList(_context.Noticia, "NoticiaId", "Titulo");
            ViewData["TagId"] = new SelectList(_context.Tag, "TagId", "Descricao");
            return View();
        }

        // POST: NoticiaTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoticiaTagId,NoticiaId,TagId")] NoticiaTag noticiaTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noticiaTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(noticiaTag);
        }

        // GET: NoticiaTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticiaTag = await _context.NoticiaTag.FindAsync(id);
            if (noticiaTag == null)
            {
                return NotFound();
            }

            ViewData["NoticiaId"] = new SelectList(_context.Noticia, "NoticiaId", "Titulo");
            ViewData["TagId"] = new SelectList(_context.Tag, "TagId", "Descricao");
            return View(noticiaTag);
        }

        // POST: NoticiaTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoticiaTagId,NoticiaId,TagId")] NoticiaTag noticiaTag)
        {
            if (id != noticiaTag.NoticiaTagId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noticiaTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticiaTagExists(noticiaTag.NoticiaTagId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["NoticiaId"] = new SelectList(_context.Noticia, "NoticiaId", "Titulo");
            ViewData["TagId"] = new SelectList(_context.Tag, "TagId", "Descricao");
            return View(noticiaTag);
        }

        // GET: NoticiaTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticiaTag = await _context.NoticiaTag
                .FirstOrDefaultAsync(m => m.NoticiaTagId == id);
            if (noticiaTag == null)
            {
                return NotFound();
            }

            return View(noticiaTag);
        }

        // POST: NoticiaTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noticiaTag = await _context.NoticiaTag.FindAsync(id);
            _context.NoticiaTag.Remove(noticiaTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticiaTagExists(int id)
        {
            return _context.NoticiaTag.Any(e => e.NoticiaTagId == id);
        }

       
        public async Task<IActionResult> Pesquisar(string descricao)
        {
            var dados = await _context.NoticiaTag
                .Include(x => x.Noticia)
                .Include(x => x.Tag)
                .Where(x => x.Tag.Descricao.Contains(descricao))
                .ToListAsync();

            if(dados.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return View("Index", dados);
        }

    }
}
