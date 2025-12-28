using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace _156023_155875.ProgWiz.DAOSQL
{
    public class KatalogContext : DbContext
    {
        public DbSet<ProducerEntity> Producers { get; set; }
        public DbSet<ShoeEntity> Shoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=katalog.db");
        }
    }
}