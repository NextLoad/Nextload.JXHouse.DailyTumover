using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nextload.JXHouse.Models.EntityConfigs
{
    public class RegionConfig : EntityTypeConfiguration<Region>
    {
        public RegionConfig()
        {
            this.ToTable("T_Region");
            this.Property(r => r.Name).HasMaxLength(32).IsRequired();
        }
    }
}
