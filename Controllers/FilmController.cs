using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TP_MODUL10_103022430004.Models;
namespace TP_MODUL10_103022430004.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : ControllerBase
    {
        private static List<Film> films = new List<Film>
        {
            new Film { Judul = "Inception", Sutradara = "Christopher Nolan", Tahun = "2010", Genre = "Sci-Fi", Rating = "9.0" },
            new Film { Judul = "Interstellar", Sutradara = "Christopher Nolan", Tahun = "2014", Genre = "Sci-Fi", Rating = "8.7" },
            new Film { Judul = "Parasite", Sutradara = "Bong Joon-ho", Tahun = "2019", Genre = "Thriller", Rating = "8.6" }
        };

        [HttpGet]
        public ActionResult<List<Film>> GetAll()
        {
            return Ok(films);
        }

        [HttpGet("{index:int}")]
        public ActionResult<Film> GetByIndex(int index)
        {
            if (index < 1 || index > films.Count)
                return NotFound($"Index {index} tidak valid. Hanya 1-{films.Count}.");
            return Ok(films[index - 1]);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Film newFilm)
        {
            films.Add(newFilm);
            return CreatedAtAction(nameof(GetByIndex), new { index = films.Count }, newFilm);
        }

        [HttpDelete("{index:int}")]
        public ActionResult Delete(int index)
        {
            if (index < 1 || index > films.Count)
                return NotFound($"Index {index} tidak valid. Hanya 1-{films.Count}.");
            films.RemoveAt(index - 1);
            return NoContent();
        }
    }
}
