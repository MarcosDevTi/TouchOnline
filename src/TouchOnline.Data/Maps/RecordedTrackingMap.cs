using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouchOnline.Domain.UserTracking;

namespace TouchOnline.Data.Maps
{
    public class RecordedTrackingMap : IEntityTypeConfiguration<RecordedTracking>
    {
        public void Configure(EntityTypeBuilder<RecordedTracking> builder)
        {
            builder.OwnsOne(_ => _.UserLocal, o => {
                o.Property(_ => _.City).HasMaxLength(120);
                o.Property(_ => _.ContinentCode).HasMaxLength(10);
                o.Property(_ => _.ContinentName).HasMaxLength(120);
                o.Property(_ => _.CountryCode).HasMaxLength(10);
                o.Property(_ => _.CountryName).HasMaxLength(120);
                o.Property(_ => _.PostalCode).HasMaxLength(50);
            });
        }
    }
}   