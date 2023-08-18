using Microsoft.EntityFrameworkCore;
using Movieslabapi.Models;

namespace Movieslabapi.Data
{
    public class ApplicationDBcontext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public ApplicationDBcontext(DbContextOptions options) : base(options)
        {

        }
    }
}
