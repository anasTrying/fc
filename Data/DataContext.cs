using ArtistAPI_DotNet8.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtistAPI_DotNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        
    }
}
