using Microsoft.EntityFrameworkCore;
using WolManagerApp.Models;

namespace WolManagerApp
{
	public class WolDBContext : DbContext
	{
		public WolDBContext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<WolData> WolData { get; set; }
	}
}
