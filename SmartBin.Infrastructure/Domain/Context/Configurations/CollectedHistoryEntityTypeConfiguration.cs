using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBin.Infrastructure.Domain.Context.Configurations
{
    public class CollectedHistoryEntityTypeConfiguration : IEntityTypeConfiguration<CollectedHistory>
    {
        public void Configure(EntityTypeBuilder<CollectedHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CollectedTime).IsRequired();
        }
    }
}
