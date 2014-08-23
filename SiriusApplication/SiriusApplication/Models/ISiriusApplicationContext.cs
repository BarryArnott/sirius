namespace SiriusApplication.Models
{
    using System.Data.Entity;

    public interface ISiriusApplicationContext
    {
        DbSet<Image> Images { get; }

        DbSet<Album> Albums { get; }
    }
}
