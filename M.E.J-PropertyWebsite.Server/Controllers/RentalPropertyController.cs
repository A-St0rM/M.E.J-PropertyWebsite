using M.E.J_PropertyWebsite.Server.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace M.E.J_PropertyWebsite.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RentalPropertyController : ControllerBase
	{
		private readonly ServerDBContext _context;

		public RentalPropertyController(ServerDBContext context)
		{
			_context = context;
		}

		[HttpGet("GetRentalProperties")]
		public IActionResult GetRentalProperties()
		{
			var rentalProperties = _context.RentalProperties.ToList();
			return Ok(rentalProperties);
		}

		[HttpGet("GetRentalPropertyById/{id}")]
		public IActionResult GetRentalPropertyById(int id)
		{
			var rentalProperty = _context.RentalProperties.FirstOrDefault(rp => rp.PropertyId == id);

			if (rentalProperty == null)
			{
				return NotFound("Rental property not found.");
			}

			return Ok(rentalProperty);
		}

		[HttpPost("AddRentalProperty")]
		public IActionResult AddRentalProperty([FromBody] RentalProperty rentalProperty)
		{
			if (rentalProperty == null || string.IsNullOrEmpty(rentalProperty.PropertyName) || string.IsNullOrEmpty(rentalProperty.PropertyType) || string.IsNullOrEmpty(rentalProperty.Location) || rentalProperty.Price == 0)
			{
				return BadRequest("Rental property details are missing.");
			}

			_context.RentalProperties.Add(rentalProperty);
			_context.SaveChanges();

			return Ok(new { Message = "Rental property added successfully!" });
		}

		[HttpPut("UpdateRentalProperty")]
		public IActionResult UpdateRentalProperty([FromBody] RentalProperty rentalProperty)
		{
			if (rentalProperty == null || rentalProperty.PropertyId == 0 || string.IsNullOrEmpty(rentalProperty.PropertyName) || string.IsNullOrEmpty(rentalProperty.PropertyType) || string.IsNullOrEmpty(rentalProperty.Location) || rentalProperty.Price == 0)
			{
				return BadRequest("Rental property details are missing.");
			}

			var existingRentalProperty = _context.RentalProperties.FirstOrDefault(rp => rp.PropertyId == rentalProperty.PropertyId);

			if (existingRentalProperty == null)
			{
				return NotFound("Rental property not found.");
			}

			existingRentalProperty.PropertyName = rentalProperty.PropertyName;
			existingRentalProperty.PropertyType = rentalProperty.PropertyType;
			existingRentalProperty.Location = rentalProperty.Location;
			existingRentalProperty.Price = rentalProperty.Price;

			_context.SaveChanges();

			return Ok(new { Message = "Rental property updated successfully!" });
		}

		[HttpDelete("DeleteRentalProperty/{id}")]
		public IActionResult DeleteRentalProperty(int id)
		{
			if (id == 0)
			{
				return BadRequest("Rental property ID is missing.");
			}

			var rentalProperty = _context.RentalProperties.FirstOrDefault(rp => rp.PropertyId == id);

			if (rentalProperty == null)
			{
				return NotFound("Rental property not found.");
			}

			_context.RentalProperties.Remove(rentalProperty);
			_context.SaveChanges();

			return Ok(new { Message = "Rental property deleted successfully!" });
		}
	}
}
