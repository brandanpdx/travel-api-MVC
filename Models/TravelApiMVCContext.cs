using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TravelApiMVC.Models
{
  public class TravelApiMVCContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Destination> Destinations { get; set; }
    public DbSet<Review> Reviews { get; set; }
    
    public TravelApiMVCContext(DbContextOptions options) : base(options) { }
  }
}