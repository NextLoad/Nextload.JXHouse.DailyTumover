using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nextload.JXHouse.Models.EntityConfigs
{
    public class TumoverConfig : EntityTypeConfiguration<Tumover>
    {
        public TumoverConfig()
        {
            this.ToTable("T_Tumover");
            this.HasRequired(t => t.Region).WithMany().HasForeignKey(t => t.RegionId).WillCascadeOnDelete(false);
            this.HasRequired(t => t.HouseUsage).WithMany().HasForeignKey(t => t.HouseUsageId).WillCascadeOnDelete(false);
        }
    }
}
