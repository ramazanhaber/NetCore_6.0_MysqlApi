using Microsoft.EntityFrameworkCore;
using MysqlApi.Models;

namespace MysqlApi.Entities
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;port=3306;database=uzaktan_aydinlatma;user=root;password=sapass;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<tbl_log> tbl_log { get; set; } 
    }
}
