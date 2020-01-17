using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumProject.ButtonLogic;

namespace EnumSpace
{
    public partial class EnumDBMap : EntityTypeConfiguration<ButtonDate>
    {
        public EnumDBMap()
        {
            this.ToTable("ButtonDate");
            this.HasKey<int>(s => s.ID);
            this.Property(t => t.Index).HasColumnName("Index");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.Browser).HasColumnName("Browser");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreateIP).HasColumnName("CreateIP");
            this.Property(t => t.CreateMac).HasColumnName("CreateMac");
        }


    }
    public partial class DictionaryPasswordMap : EntityTypeConfiguration<DictionaryPassword>
    {
        public DictionaryPasswordMap()
        {
            this.ToTable("DictionaryPassword");
            this.HasKey<int>(s => s.ID);
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Plaintext).HasColumnName("Plaintext"); ;
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.PwdType).HasColumnName("PwdType");
        }

    }
}
