using ListaDeVideosApi.Controllers;
using Microsoft.EntityFrameworkCore;

namespace ListaDeVideosApi.Data
{

    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ListaDeVideos> ListaDeVideosDb { get; set; }
    }
}
