using ICI.ProvaCandidato.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace UniApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<NoticiaTag> NoticiaTag { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("DataSource=app.db;Cache=Shared");

    }
}