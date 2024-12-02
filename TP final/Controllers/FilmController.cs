using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP_final.Datas;
using TP_final.Datas.Enums;
using TP_final.Models;

namespace TP_final.Controllers
{
    public class FilmController : Controller
    {
        private readonly AddDbContext _Context;
        public FilmController(AddDbContext context)
        {
            _Context = context;
        }
        public async Task<IActionResult> Index()
        {
            var couleurs = Enum.GetValues(typeof(FilmCategorie))
                               .Cast<FilmCategorie>()
                               .Select(e => new SelectListItem
                               {
                                   Value = ((int)e).ToString(),
                                   Text = e.ToString()
                               });

            ViewBag.CouleursListe = couleurs;
            var data = await _Context.Films.ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(films film)
        {
                if (_Context.Films.Any(d => d.Nom.Equals(film.Nom)))
                {
                    ViewBag.Erreur = "Ce film existe deja";
                    return View(film);
                }
                _Context.Films.Add(film);
                _Context.SaveChanges();
                return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            films film = _Context.Films.FirstOrDefault(a => a.Id.Equals(id));
            if (film == null)
            {
                return View("NotFound");
            }
            return View(film);
        }
        [HttpPost]
        public IActionResult Edit(films film)
        {
            if (_Context.Films.Any(a => a.Id.Equals(film.Id)))
            {
                _Context.Films.Update(film);
                _Context.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.Erreur = "Ce film n'existe pas";
            return RedirectToAction("index");

        }

        public async Task<IActionResult> Details(int id)
        {
            var filmDetails = await _Context.Films
                                .Include(af => af.ActeurFilms)
                                .ThenInclude(a => a.Acteur)
                                .FirstOrDefaultAsync(a => a.Id == id);

            if (filmDetails == null)
            {
                return View("NotFound");
            }
            return View(filmDetails);
        }

        public IActionResult Delete(int id)
        {
            films film = _Context.Films.FirstOrDefault(a => a.Id.Equals(id));
            if (film == null)
            {
                return View("NotFound");
            }
            return View(film);
        }
        [HttpPost]
        public IActionResult Delete(films film)
        {
            _Context.Films.Remove(film);
            _Context.SaveChanges();
            return View(film);
        }
    }
}
