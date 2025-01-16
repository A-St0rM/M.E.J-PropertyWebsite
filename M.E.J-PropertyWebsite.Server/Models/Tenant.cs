namespace M.E.J_PropertyWebsite.Server.Models
{
	public class Tenant
	{
		public int TenantId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }

		public Tenant(int tenantId, string firstName, string lastName, string email, string phoneNumber)
		{
			this.TenantId = tenantId;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Email = email;
			this.PhoneNumber = phoneNumber;
		}
	}


}
