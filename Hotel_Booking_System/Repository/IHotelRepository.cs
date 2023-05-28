using Hotel_Booking_System.Model;
using Hotel_Booking_System.Model;

namespace Hotel_Booking_System.Repository
{
	public interface IHotelRepository
	{
		Hotel GetHotelById(int id);
		IEnumerable<Hotel> GetAllHotels();
		void AddHotel(Hotel hotel);
		void UpdateHotel(Hotel hotel);
		void DeleteHotel(int id);
	}
}
