using Hotel_Booking_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Booking_System.Repository
{
	public class FilterRepository : IFilterRepository
	{
		private readonly HRContext _dbContext;

		public FilterRepository(HRContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IEnumerable<Hotel> GetFilteredHotels(string location, decimal? minPrice, decimal? maxPrice)
		{
			try
			{
				var hotels = _dbContext.Set<Hotel>().AsQueryable();

				if (!string.IsNullOrEmpty(location))
					hotels = hotels.Where(h => h.HLocation.Contains(location));

				if (minPrice != null)
					hotels = hotels.Where(h => h.HPrice >= minPrice);

				if (maxPrice != null)
					hotels = hotels.Where(h => h.HPrice <= maxPrice);

				return hotels.ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Failed to retrieve filtered hotels", ex);
				return new List<Hotel>(); 
			}
		}

		public int Results(int id)
		{
			try
			{
				Hotel hotel = _dbContext.Hotels.FirstOrDefault(h => h.HId == id);
				if (hotel != null)
				{
					int availableRoomsCount = _dbContext.Rooms.Count(r => r.HId == id && r.RAvailability == true);
					return availableRoomsCount;
				}
				return 0;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Failed to retrieve available room count", ex);
				return 0; 
			}
		}
	}
}
