using Hotel_Booking_System.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Hotel_Booking_System.Repository
{
	public class HotelRepository : IHotelRepository
	{
		private readonly HRContext _dbContext;

		public HotelRepository(HRContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void AddHotel(Hotel hotel)
		{
			try
			{
				_dbContext.Set<Hotel>().Add(hotel);
				_dbContext.SaveChanges();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Failed to add hotel", ex);
			}
		}

		public void DeleteHotel(int id)
		{
			try
			{
				var hotel = _dbContext.Set<Hotel>().Find(id);
				if (hotel != null)
				{
					_dbContext.Set<Hotel>().Remove(hotel);
					_dbContext.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Failed to delete hotel", ex);
			}
		}

		public IEnumerable<Hotel> GetAllHotels()
		{
			try
			{
				return _dbContext.Set<Hotel>().ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Failed to retrieve hotels", ex);
				return new List<Hotel>(); 
			}
		}

		public Hotel GetHotelById(int id)
		{
			try
			{
				return _dbContext.Set<Hotel>().Find(id);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Failed to retrieve hotel", ex);
				return null; 
			}
		}

		public void UpdateHotel(Hotel hotel)
		{
			try
			{
				_dbContext.Entry(hotel).State = EntityState.Modified;
				_dbContext.SaveChanges();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Failed to update hotel", ex);
			}
		}
	}
}
