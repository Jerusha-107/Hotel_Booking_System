using Hotel_Booking_System.Model;

namespace Hotel_Booking_System.Repository
{
	public interface IRoomRepository
	{
		Room GetRoomById(int id);
		IEnumerable<Room> GetAllRoom();
		void AddRoom(Room Rooms);
		void UpdateRoom(Room Rooms, int id);
		void DeleteRoom(int id);
	}
}
