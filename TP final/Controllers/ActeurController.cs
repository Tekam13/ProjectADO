using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_final.Datas;
using TP_final.Models;

namespace TP_final.Controllers
{
    public class ActeurController : Controller
    {
        private readonly AddDbContext _Context;
        public ActeurController(AddDbContext context)
        {
            _Context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _Context.Acteurs.ToListAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create([Bind("Nom, Photo, bibloigraphie")] Acteur acteur)
        {
            if (!ModelState.IsValid)
            {
                if (_Context.Acteurs.Any(d => d.Id.Equals(acteur.Id)))
                {
                    ViewBag.Erreur = "Cet auteur existe deja";
                    return View(acteur);
                }
                _Context.Acteurs.Add(acteur);
                _Context.SaveChanges();
                return RedirectToAction("index");
            }
            return RedirectToAction(nameof(Create));
        }
        public IActionResult Edit(int id)
        {
            Acteur acteur = _Context.Acteurs.FirstOrDefault(a => a.Id.Equals(id));
            if (acteur == null)
            {
                return View("NotFound");
            }
            return View(acteur);
        }
        [HttpPost]
        public IActionResult Edit(Acteur acteur)
        {
            if (_Context.Acteurs.Any(a => a.Id.Equals(acteur.Id)))
            {
                _Context.Acteurs.Update(acteur);
                _Context.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.Erreur = "Ce diplome n'existe pas";
            return RedirectToAction("index");

        }
        public IActionResult Details(int id)
        {
            var acteurDetails = _Context.Acteurs.FirstOrDefault(a => a.Id == id); 
            if (acteurDetails == null)
            {
                return View("NotFound");
            }
            return View(acteurDetails);
        }

        public IActionResult Delete(int id)
        {
            Acteur acteur = _Context.Acteurs.FirstOrDefault(d => d.Id.Equals(id));
            if (acteur == null)
            {
                return NotFound();
            }
            _Context.Acteurs.Remove(acteur);
            _Context.SaveChanges();
            return View(acteur);
        }
        [HttpPost]
        public IActionResult Delete(Acteur acteur)
        {
            return RedirectToAction("index");
        }
    }
}
