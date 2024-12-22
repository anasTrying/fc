using ArtistAPI_DotNet8.Data;
using ArtistAPI_DotNet8.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ArtistAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly DataContext _context;

        public ArtistController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Artist>>> GetAllArtists()
        {
            var artists = await _context.Artists.ToListAsync();

            return Ok(artists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist is null)
                return NotFound("Artist not found.");

            return Ok(artist);
        }

        [HttpPost]
        public async Task<ActionResult<List<Artist>>> AddArtist(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();

            return Ok(await _context.Artists.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Artist>>> UpdateArtist(Artist updatedArtist)
        {
            var dbArtist = await _context.Artists.FindAsync(updatedArtist.ArtistId);
            if (dbArtist is null)
                return NotFound("Artist not found.");

            dbArtist.Name = updatedArtist.Name;
            dbArtist.FirstName = updatedArtist.FirstName;
            dbArtist.LastName = updatedArtist.LastName;
            dbArtist.Place = updatedArtist.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.Artists.ToListAsync());
        }
        [HttpDelete]
        public async Task<ActionResult<List<Artist>>> DeleteArtist(int id)
        {
            var dbArtist = await _context.Artists.FindAsync(id);
            if (dbArtist is null)
                return NotFound("Artist not found.");

            _context.Artists.Remove(dbArtist);
            await _context.SaveChangesAsync();

            return Ok(await _context.Artists.ToListAsync());
        }
    }
}

