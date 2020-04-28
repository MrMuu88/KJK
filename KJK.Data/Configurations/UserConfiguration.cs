using KJK.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KJK.Data.Configurations
{
	class UserConfiguration:BaseModelConfiguration<User>
	{
		public override void Configure(EntityTypeBuilder<User> builder)
		{
			base.Configure(builder);
			builder.Property(u => u.Email).IsRequired();
			builder.Property(u => u.NickName).IsRequired();
			builder.Property(u => u.Password).IsRequired();
		}
	}
}
