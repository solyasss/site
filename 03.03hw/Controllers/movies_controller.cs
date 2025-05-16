using _03._03hw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace _03._03hw.Controllers;

public class MoviesController : Controller
    {
        private readonly movie_context _db;
        private readonly IWebHostEnvironment _env;

        public MoviesController(movie_context context, IWebHostEnvironment env)
        {
            _db = context;
            _env = env;
        }
        
        public async Task<IActionResult> index()
        {
            var list = await _db.movies.ToListAsync();
            return View("~/Views/movies_crud/index.cshtml", list);
        }
        
        public async Task<IActionResult> details(int? id)
        {
            if (id == null) return NotFound();
            var current_movie = await _db.movies.FirstOrDefaultAsync(m => m.id == id);
            if (current_movie == null) return NotFound();
            return View("~/Views/movies_crud/details.cshtml", current_movie);
        }
        
        public IActionResult create()
        {
            return View("~/Views/movies_crud/create.cshtml");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(1000000000)]
        public async Task<IActionResult> Create(
            [Bind("id,title,director,genre,year,description")] movie new_movie,
            IFormFile uploaded_poster)
        
        {
            
            ModelState.Remove("poster");

            if (!ModelState.IsValid)
            {
                return View("~/Views/movies_crud/create.cshtml", new_movie);
            }

            
            if (uploaded_poster != null)
            {
                string file_name = Path.GetFileName(uploaded_poster.FileName);
                string path = "/uploaded_images/" + file_name;
                using (var stream = new FileStream(_env.WebRootPath + path, FileMode.Create))
                {
                    await uploaded_poster.CopyToAsync(stream);
                }
                new_movie.poster = path;
            }
            _db.movies.Add(new_movie);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> edit(int? id)
        {
            if (id == null) return NotFound();
            var current_movie = await _db.movies.FindAsync(id);
            if (current_movie == null) return NotFound();
            return View("~/Views/movies_crud/edit.cshtml", current_movie);
        }

      [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> edit(
    int id, 
    [Bind("id,title,director,genre,year,poster,description")] movie changed_movie,
    IFormFile uploaded_poster)
{
    if (id != changed_movie.id) return NotFound();

    ModelState.Remove("poster");

    if (!ModelState.IsValid)
    {
        return View("~/Views/movies_crud/edit.cshtml", changed_movie);
    }

    try
    {
        var existing_movie = await _db.movies.FindAsync(id);
        if (existing_movie == null) return NotFound();

        if (uploaded_poster != null)
        {
            if (!string.IsNullOrEmpty(existing_movie.poster))
            {
                string old_file_path = Path.Combine(_env.WebRootPath, existing_movie.poster.TrimStart('/'));
                if (System.IO.File.Exists(old_file_path))
                {
                    System.IO.File.Delete(old_file_path);
                }
            }

            string file_name = Path.GetFileName(uploaded_poster.FileName);
            string new_path = "/uploaded_images/" + file_name;
            using (var stream = new FileStream(_env.WebRootPath + new_path, FileMode.Create))
            {
                await uploaded_poster.CopyToAsync(stream);
            }
        }
        else
        {
            changed_movie.poster = existing_movie.poster;
        }

        _db.Entry(existing_movie).CurrentValues.SetValues(changed_movie);
        await _db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!await _db.movies.AnyAsync(m => m.id == changed_movie.id))
        {
            return NotFound();
        }
        else
        {
            throw;
        }
    }
    return RedirectToAction(nameof(index));
}

        public async Task<IActionResult> delete(int? id)
        {
            if (id == null) return NotFound();
            var current_movie = await _db.movies.FirstOrDefaultAsync(m => m.id == id);
            if (current_movie == null) return NotFound();
            return View("~/Views/movies_crud/delete.cshtml", current_movie);
        }

        [HttpPost, ActionName("delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> delete_confirmed(int id)
        {
            var current_movie = await _db.movies.FindAsync(id);
            if (current_movie != null)
            {
                if (!string.IsNullOrEmpty(current_movie.poster))
                {
                    string file_path = Path.Combine(_env.WebRootPath, current_movie.poster.TrimStart('/'));
                    if (System.IO.File.Exists(file_path))
                    {
                        System.IO.File.Delete(file_path);
                    }
                }

                _db.movies.Remove(current_movie);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(index));
        }

    }
