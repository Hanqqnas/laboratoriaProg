using Microsoft.EntityFrameworkCore;

namespace laboratoriaProg.Models.Movies
{
    public partial class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }
    }
}