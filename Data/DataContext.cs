using Asp_Net_Core_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp_Net_Core_Back.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Atividade> Atividades { get; set; }
    }
}
