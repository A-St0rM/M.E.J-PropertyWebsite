namespace M.E.J_PropertyWebsite.Server.DTO
{
    public class WaitingListDTO
    {
        public int WaitingListId { get; set; }
        public int RentalPropertyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
