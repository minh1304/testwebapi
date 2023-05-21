using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISupperHeroService

    {
        private readonly DataContext _context;

        public SuperHeroService(DataContext contex)
        {
            _context = contex;
        }
        public async Task<List<SuperHero>> AddHero([FromBody] SuperHero hero)
        {
            var check = await _context.SuperHeroes.FirstOrDefaultAsync(x => x.Id == hero.Id || x.Name == hero.Name);
            if (check == null)
            {
                _context.SuperHeroes.Add(hero);
                await _context.SaveChangesAsync();
                return await _context.SuperHeroes.ToListAsync();
            }
            else
            {
                return null;
            }

        }
        /*            var check = _context.SuperHeroes.FirstOrDefaultAsync(h => h.Id == hero.Id || h.Name == hero.Name);
                    if (check is null)
                    {
                        await _context.SuperHeroes.AddAsync(hero);
                        await _context.SaveChangesAsync();
                        return await _context.SuperHeroes.ToListAsync();
                    }
                    else
                    {
                        return null;
                    }*/

        public async Task<List<SuperHero>>? DeleteHero(int? id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> GetAllHeros()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero>? GetSingleHero(int? id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            return hero;
        }

        public async Task<List<SuperHero>>? UpdateHero(int? id, SuperHero request)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
