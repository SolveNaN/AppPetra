using ControWell.Client.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            var heroes =await _context.SuperHeroes.Include(sh=>sh.Comic).ToListAsync();
            return Ok(heroes);
        }
        [HttpGet("Comics")]
        public async Task<ActionResult<List<Comic>>> GetComics()
        {
            var comics = await _context.Comics.ToArrayAsync();
            return Ok(comics);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHeroes(int id)
        {
            var hero = await _context.SuperHeroes.
                Include(h=>h.Comic)
                .FirstOrDefaultAsync(h => h.Id == id);
            if(hero == null)
            {
                return NotFound("Lo siento, el heroe no se encuentra :/");
            }
            
            return Ok(hero);
        }

        [HttpPost]
        
        public async Task<ActionResult<SuperHero>> CreateSuperHero(SuperHero hero)
        {
            hero.Comic = null;
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await GetDbHeroes());
        }




        [HttpPut("{id}")]

        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero hero,int id)
        {
            var dbHero=await _context.SuperHeroes
                .Include(sh=>sh.Comic)
                .FirstOrDefaultAsync(sh=>sh.Id == id);
            if (dbHero == null)
                return NotFound("Sorry, pero el heroe no existe");
            dbHero.FirstName=hero.FirstName;
            dbHero.LastName=hero.LastName;
            dbHero.HeroName=hero.HeroName;
            dbHero.ComicId=hero.ComicId;

            await _context.SaveChangesAsync();
            return Ok(await GetDbHeroes());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            var dbHero = await _context.SuperHeroes.
                Include(h => h.Comic)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbHero == null)
            {
                return NotFound("Lo siento, el heroe no se encuentra :/");
            }

            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        private async Task<List<SuperHero>> GetDbHeroes()
        {
            return await _context.SuperHeroes.Include(sh => sh.Comic).ToListAsync();
        }
    }
}
