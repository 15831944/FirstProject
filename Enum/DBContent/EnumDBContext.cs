using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4ConsoleApplication.Entities;

namespace EnumSpace
{
   public partial class EnumDBContext : DbContext
    {
        public DbSet<ButtonDate> ButtonDate { get; set; }

        public EnumDBContext()
            : base("name=sqlstring")
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EnumDBMap());
            modelBuilder.Configurations.Add(new DictionaryPasswordMap());
        }
    }
}
