namespace todoist.Infraestructure.Entities
{
    public class User : Entity
    {
        public int? UserTypeId { get; set; }

        public string Username { get; set; }
    }
}