using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Hotel_Booking_System.Model
{
	public class Hotel
	{
		[Key]
		public int HId { get; set; }
		public string? HName { get; set; }
		public string? HLocation { get; set; }
		public int StarRating { get; set; }
		public int HPrice { get; set; }
		public string? HEmail { get; set; }
		public string? HContactPhone { get; set; }
		public ICollection<Room>? Rooms { get; set; }
	}
}
