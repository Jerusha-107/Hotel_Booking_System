using Hotel_Booking_System.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Booking_System.Repository
{
	public class RoomRepository : IRoomRepository
	{
		private readonly HRContext _dbContext;

		public RoomRepository(HRContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Room GetRoomById(int id)
		{
			try
			{
				return _dbContext.Rooms.Find(id);
			}
			catch (Exception ex)
			{
				
				Console.WriteLine("Failed to retrieve room by id: " + ex.Message);
				return null; 
			}
		}

		public IEnumerable<Room> GetAllRoom()
		{
			try
			{
				return _dbContext.Rooms.ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Failed to retrieve all rooms: " + ex.Message);
				return new List<Room>(); 
			}
		}

		public void AddRoom(Room rooms)
		{
			try
			{
				_dbContext.Rooms.Add(rooms);
				_dbContext.SaveChanges();
			}
			catch (Exception ex)
			{
				
				Console.WriteLine("Failed to add room: " + ex.Message);
			}
		}

		public void UpdateRoom(Room rooms, int id)
		{
			try
			{
				var ur = _dbContext.Rooms.Find(id);
				if (ur != null)
				{
					ur.RAvailability = rooms.RAvailability;
					_dbContext.Rooms.Update(ur);
					_dbContext.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				
				Console.WriteLine("Failed to update room: " + ex.Message);
			}
		}

		public void DeleteRoom(int id)
		{
			try
			{
				var room = _dbContext.Rooms.Find(id);
				if (room != null)
				{
					_dbContext.Rooms.Remove(room);
					_dbContext.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				
				Console.WriteLine("Failed to delete room: " + ex.Message);
			}
		}
	}
}
