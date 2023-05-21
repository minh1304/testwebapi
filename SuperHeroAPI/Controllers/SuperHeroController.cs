using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISupperHeroService _superHeroService;

        public SuperHeroController(ISupperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }
        //GET all super heroes
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            return await _superHeroService.GetAllHeros();
        }

        //GET single super hero
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int? id)
        {
            var result = await _superHeroService.GetSingleHero(id);
            if (result is null)
            {
                return NotFound("Sorry, but this hero doesn't exist.");
            }
            return Ok(result);
        }

        //POST add hero
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody] SuperHero hero)
        {
            /*            var result = await _superHeroService.AddHero(hero);
                        if (result is null)
                        {
                            return NotFound("Hero not found!");
                        }
                        return Ok(result);*/

            var result = await _superHeroService.AddHero(hero);
            if (result is null)
            {
                return NotFound("Hero can't add");
            }
            return Ok(result);

        }
        //PUT adjust hero (all)
        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int? id, SuperHero request)
        {
            var result = await _superHeroService.UpdateHero(id, request);
            if (result is null)
            {
                return NotFound("Hero not found!");
            }
            return Ok(result);

        }
        //PATCH adjust one prop 


        //DELETE 
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int? id)
        {
            var result = await _superHeroService.DeleteHero(id);
            if (result is null)
            {
                return NotFound("Hero not found!");
            }
            return Ok(result);


        }
    }
}
