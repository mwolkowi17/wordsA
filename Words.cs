using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace WordsA{
    class Words:DbContext{
        public DbSet <Tabela> Slownik{ get; set;}
        public DbSet <Grade> Efekty {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=slownik.db");
    }
}