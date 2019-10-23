using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nextload.JXHouse.Models.EntityConfigs
{
    public class TotalTumoverConfig : EntityTypeConfiguration<TotalTumover>
    {
        public TotalTumoverConfig()
        {
            this.ToTable("T_TotalTumover");
            this.HasRequired(t => t.HouseUsage2).WithMany().HasForeignKey(t => t.HouseUsage2Id).WillCascadeOnDelete(false);
        }
    }
}
