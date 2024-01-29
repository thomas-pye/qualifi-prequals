using Microsoft.EntityFrameworkCore;

namespace efmodels;
public class Context : DbContext
{
    public virtual DbSet<Prequalification> Prequalifications { get; set; }
    public virtual DbSet<Loan> Loans { get; set; }

    public string DbPath { get; }

    public Context(DbContextOptions<Context> options)
    : base(options)
    {       
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "prequalifications.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}