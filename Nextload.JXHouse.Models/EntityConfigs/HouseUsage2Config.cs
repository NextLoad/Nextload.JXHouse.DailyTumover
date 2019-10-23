using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nextload.JXHouse.Models.EntityConfigs
{
    public class HouseUsage2Config : EntityTypeConfiguration<HouseUsage2>
    {
        public HouseUsage2Config()
        {
            this.ToTable("T_HouseUsage2");
            this.Property(r => r.Name).HasMaxLength(8).IsRequired().IsUnicode(false);
        }
    }
}
