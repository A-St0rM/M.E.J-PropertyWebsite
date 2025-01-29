namespace M.E.J_PropertyWebsite.Server.Models
{
	public class RentalProperty
	{
		public int RentalPropertyId { get; set; }
		public int? TenantId { get; set; }
		public string PropertyName { get; set; }
		public string PropertyAddress { get; set; }
		public string Description { get; set; }
		public double PropertySquareFootage { get; set; }
		public bool IsAvailable { get; set; }
		public int RentalPrice { get; set; }
		public int Deposit { get; set; }
		public double Aconto { get; set; }
		public bool PetsAllowed { get; set; }
		public int PropertyRoomSize { get; set; }
		public DateTime DateAvailable { get; set; }

		public RentalProperty(int rentalPropertyId, int? tenantId, string propertyName, string propertyAddress, string description, double propertySquareFootage, bool isAvailable, int rentalPrice, int deposit, double aconto, bool petsAllowed, int propertyRoomSize, DateTime dateAvailable)
		{
			this.RentalPropertyId = rentalPropertyId;
			this.TenantId = tenantId;
			this.PropertyName = propertyName;
			this.PropertyAddress = propertyAddress;
			this.Description = description;
			this.PropertySquareFootage = propertySquareFootage;
			this.IsAvailable = isAvailable;
			this.RentalPrice = rentalPrice;
			this.Deposit = deposit;
			this.Aconto = aconto;
			this.PetsAllowed = petsAllowed;
			this.PropertyRoomSize = propertyRoomSize;
			this.DateAvailable = dateAvailable;
		}
	}
}
