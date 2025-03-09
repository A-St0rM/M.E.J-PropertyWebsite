namespace M.E.J_PropertyWebsite.Server.Models
{
    public class PropertyType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PropertyType(string Name)
        {
            this.Name = Name;
        }

        public PropertyType()
        {
        }
    }
}
