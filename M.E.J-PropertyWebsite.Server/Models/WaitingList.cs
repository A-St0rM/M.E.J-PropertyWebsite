namespace M.E.J_PropertyWebsite.Server.Models
{
    public class WaitingList
    {
        public int WaitingListId { get; set; }
        public int RentalPropertyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateAdded { get; set; }

        public WaitingList(int RentalPropertyId, string Name, string Email, string PhoneNumber, DateTime DateAdded)
        {
            this.RentalPropertyId = RentalPropertyId;
            this.Name = Name;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.DateAdded = DateAdded;
        }

        public WaitingList()
        {
        }
    }
}
