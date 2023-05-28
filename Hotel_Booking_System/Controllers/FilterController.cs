using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hotel_Booking_System.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Hotel_Booking_System.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class FilterController : ControllerBase
	{
		private readonly IFilterRepository _hotelRepository;

		public FilterController(IFilterRepository hotelRepository)
		{
			_hotelRepository = hotelRepository;
		}
		[HttpGet]
		public IActionResult GetAllHotels(string location = null, decimal? minPrice = null, decimal? maxPrice = null)
		{
			var hotels = _hotelRepository.GetFilteredHotels(location, minPrice, maxPrice);
			return Ok(hotels);
		}

		[HttpGet("{id}")]
		public int GetCount(int id)
		{
			var res = _hotelRepository.Results(id);

			return res;
		}

	}
}
