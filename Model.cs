using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace efcore_test {
    public class TestContext : DbContext {
        public DbSet<TestTable> TestTables {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=test.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TestTable>()
                .HasKey(o => o.KeyColumn1);
        }
    }

    public class TestTable {
        public Guid KeyColumn1 { get; set; }
        public Guid OtherColumn2 { get; set; }
    }
}