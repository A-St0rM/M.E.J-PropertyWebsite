using M.E.J_PropertyWebsite.Server.Database;
using M.E.J_PropertyWebsite.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
			var rentalProperties = _context.RentalProperties
				.Select(rp => new
				{
					rp.RentalPropertyId,
					rp.PropertyName,
					rp.PropertyAddress,
					rp.Description,
					rp.PropertySquareFootage,
					rp.IsAvailable,
					rp.RentalPrice,
					rp.Deposit,
					rp.Aconto,
					rp.PetsAllowed,
					rp.PropertyRoomSize,
					rp.DateAvailable,
					rp.TenantId,
					Tenant = rp.TenantId.HasValue ? _context.Tenants.FirstOrDefault(t => t.TenantId == rp.TenantId) : null
				})
				.ToList();

			return Ok(rentalProperties);
		}

		[HttpGet("GetRentalPropertyById/{id}")]
		public IActionResult GetRentalPropertyById(int id)
		{
			var rentalProperty = _context.RentalProperties
				.Where(rp => rp.RentalPropertyId == id)
				.Select(rp => new
				{
					rp.RentalPropertyId,
					rp.PropertyName,
					rp.PropertyAddress,
					rp.Description,
					rp.PropertySquareFootage,
					rp.IsAvailable,
					rp.RentalPrice,
					rp.Deposit,
					rp.Aconto,
					rp.PetsAllowed,
					rp.PropertyRoomSize,
					rp.DateAvailable,
					rp.TenantId,
					Tenant = rp.TenantId.HasValue ? _context.Tenants.FirstOrDefault(t => t.TenantId == rp.TenantId) : null
				})
				.FirstOrDefault();

			if (rentalProperty == null)
			{
				return NotFound("Rental property not found.");
			}

			return Ok(rentalProperty);
		}

		[HttpPost("AddRentalProperty")]
		public IActionResult AddRentalProperty([FromBody] RentalProperty rentalProperty)
		{
			if (rentalProperty == null || string.IsNullOrEmpty(rentalProperty.PropertyName) || string.IsNullOrEmpty(rentalProperty.PropertyAddress) || rentalProperty.RentalPrice == 0)
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
			if (rentalProperty == null || rentalProperty.RentalPropertyId == 0 || string.IsNullOrEmpty(rentalProperty.PropertyName) || string.IsNullOrEmpty(rentalProperty.PropertyAddress) || rentalProperty.RentalPrice == 0)
			{
				return BadRequest("Rental property details are missing.");
			}

			var existingRentalProperty = _context.RentalProperties.FirstOrDefault(rp => rp.RentalPropertyId == rentalProperty.RentalPropertyId);

			if (existingRentalProperty == null)
			{
				return NotFound("Rental property not found.");
			}

			existingRentalProperty.PropertyName = rentalProperty.PropertyName;
			existingRentalProperty.PropertyAddress = rentalProperty.PropertyAddress;
			existingRentalProperty.Description = rentalProperty.Description;
			existingRentalProperty.PropertySquareFootage = rentalProperty.PropertySquareFootage;
			existingRentalProperty.IsAvailable = rentalProperty.IsAvailable;
			existingRentalProperty.RentalPrice = rentalProperty.RentalPrice;
			existingRentalProperty.Deposit = rentalProperty.Deposit;
			existingRentalProperty.Aconto = rentalProperty.Aconto;
			existingRentalProperty.PetsAllowed = rentalProperty.PetsAllowed;
			existingRentalProperty.PropertyRoomSize = rentalProperty.PropertyRoomSize;
			existingRentalProperty.DateAvailable = rentalProperty.DateAvailable;
			existingRentalProperty.TenantId = rentalProperty.TenantId;

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

			var rentalProperty = _context.RentalProperties.FirstOrDefault(rp => rp.RentalPropertyId == id);

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
