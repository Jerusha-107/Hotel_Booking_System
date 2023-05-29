using Hotel_Booking_System.Model;
using Hotel_Booking_System.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking_System.Controllers
{
        [Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class HotelController : ControllerBase
	{
		private readonly IHotelRepository _hotelRepository;

		public HotelController(IHotelRepository HotelRepository)
		{
			_hotelRepository = HotelRepository;
		}

		[HttpGet]
		public IActionResult GetAllHotels()
		{
			var hotels = _hotelRepository.GetAllHotels();
			return Ok(hotels);
		}

		[HttpGet("{id}")]
		public IActionResult GetHotelById(int id)
		{
			var hotel = _hotelRepository.GetHotelById(id);
			if (hotel == null)
				return NotFound();

			return Ok(hotel);
		}

		[HttpPost]
		public IActionResult CreateHotel([FromBody] Hotel hotel)
		{
			_hotelRepository.AddHotel(hotel);
			return CreatedAtAction(nameof(GetHotelById), new { id = hotel.HId }, hotel);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateHotel(int id, [FromBody] Hotel hotel)
		{
			if (id != hotel.HId)
				return BadRequest();

			_hotelRepository.UpdateHotel(hotel);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteHotel(int id)
		{
			_hotelRepository.DeleteHotel(id);
			return NoContent();
		}
	}
}
