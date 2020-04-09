using KJK.Data;
using Microsoft.EntityFrameworkCore;

namespace KJK.Tests
{
	public static class Constants
	{
		public static DbContextOptions<KJKDbContext> GetOptions(DbType type) {
			var builder =  new DbContextOptionsBuilder<KJKDbContext>();
			
			switch (type)
			{
				case DbType.InMemory:
					builder.UseInMemoryDatabase("KJKDB");
					break;
				case DbType.SqlServer:
					builder.UseSqlServer("Server = localhost; Database = KJKDB; Trusted_Connection = True;");
					break;
				default:
					return null;
			}

			return builder.Options;

		}
	}
	public enum DbType { InMemory,SqlServer}
}
