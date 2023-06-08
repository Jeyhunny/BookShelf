using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class BookShelfConfiguration : IEntityTypeConfiguration<BookShelf>
    {
        public void Configure(EntityTypeBuilder<BookShelf> builder)
        {

            builder.Property(m => m.CreateDate).HasDefaultValue(DateTime.UtcNow);


            builder.HasQueryFilter(m => !m.SoftDeleted);
        }
    }


}
