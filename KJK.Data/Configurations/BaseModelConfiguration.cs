using KJK.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KJK.Data.Configurations
{
	public abstract class  BaseModelConfiguration<T> : IEntityTypeConfiguration<T> where T:BaseModel
	{
		public virtual void Configure(EntityTypeBuilder<T> builder)
		{
			builder.HasKey(bm => bm.Id);
		}
	}
}
