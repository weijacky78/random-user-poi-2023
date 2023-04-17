
using Microsoft.EntityFrameworkCore;

namespace places_webapi.Models;

public class PlacesContext : DbContext
{

    public PlacesContext(DbContextOptions<PlacesContext> options)
    : base(options)
    {
    }

    public DbSet<Place> Places { get; set; } = default!;
}