using Hotel_Booking_System.Model;
using Hotel_Booking_System.Model;

namespace Hotel_Booking_System.Repository
{
	public interface IFilterRepository
	{
		IEnumerable<Hotel> GetFilteredHotels(string? location, decimal? minPrice, decimal? maxPrice);
		int Results(int id);
	}
}
