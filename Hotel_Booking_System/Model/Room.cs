using System.ComponentModel.DataAnnotations;

namespace Hotel_Booking_System.Model
{
	public class Room
	{
		[Key]
		public int RId { get; set; }
		public string? RoomType { get; set; }
		public bool RAvailability { get; set; }
		public int RPrice { get; set; }
		public int RCapacity { get; set; }
		public string? RView { get; set; }
		public bool HasWifi { get; set; }
		public int HId { get; set; }
		public Hotel? Hotel { get; set; }
	}
}
