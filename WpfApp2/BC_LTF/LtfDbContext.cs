using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Model;

namespace WpfApp2.BC_LTF
{
    public class LtfDbContext:DbContext
    {
        public DbSet<LtfSicaklikModel> LtfSicakliklar { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cnnStr = "server=.; database=pandapDb;user Id=sa;password=Ankara!06";
           
            optionsBuilder.UseSqlServer(cnnStr);

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Uretim");

        

            
            base.OnModelCreating(modelBuilder);

        }


    }
}
