using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Hotel_Booking_System.Model
{
	public class HRContext : DbContext
	{
		public DbSet<Hotel> Hotels { get; set; }
		public DbSet<Room> Rooms { get; set; }

		public HRContext(DbContextOptions<HRContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Hotel>()
				.HasMany(h => h.Rooms)
				.WithOne(r => r.Hotel)
				.HasForeignKey(r => r.HId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}