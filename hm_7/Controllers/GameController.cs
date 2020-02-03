using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using hm_7.Models;
using System.Threading.Tasks;

namespace WebAPIApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        GamesContext db;
        public GamesController(GamesContext context)
        {
            db = context;
            if (!db.Games.Any())
            {
                db.Games.Add(new Game { name = "DOOM", category = "shooter"});
                db.Games.Add(new Game { name = "Cookie Clicker", category = "idle" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> Get()
        {
            return await db.Games.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> Get(int id)
        {
            Game game = await db.Games.FirstOrDefaultAsync(x => x.id == id);
            if (game == null)
                return NotFound();
            return new ObjectResult(game);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Game>> Post(Game game)
        {
            if (game == null)
            {
                return BadRequest();
            }

            db.Games.Add(game);
            await db.SaveChangesAsync();
            return Ok(game);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Game>> Put(Game game)
        {
            if (game == null)
            {
                return BadRequest();
            }
            if (!db.Games.Any(x => x.id == game.id))
            {
                return NotFound();
            }

            db.Update(game);
            await db.SaveChangesAsync();
            return Ok(game);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> Delete(int id)
        {
            Game game = db.Games.FirstOrDefault(x => x.id == id);
            if (game == null)
            {
                return NotFound();
            }
            db.Games.Remove(game);
            await db.SaveChangesAsync();
            return Ok(game);
        }
    }
}