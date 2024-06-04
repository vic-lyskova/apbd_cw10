using Microsoft.EntityFrameworkCore;

namespace Cw10.Context;

public class ApbdContext : DbContext
{
    protected ApbdContext()
    {
    }

    public ApbdContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<> Type { get; set; }
}