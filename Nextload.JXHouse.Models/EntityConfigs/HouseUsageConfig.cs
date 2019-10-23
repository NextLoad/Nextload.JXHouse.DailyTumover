using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nextload.JXHouse.Models.EntityConfigs
{
    public class HouseUsageConfig : EntityTypeConfiguration<HouseUsage>
    {
        public HouseUsageConfig()
        {
            this.ToTable("T_HouseUsage");
            this.Property(r => r.Name).HasMaxLength(8).IsRequired();
        }
    }
}
