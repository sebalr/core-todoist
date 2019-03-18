namespace todoist.infraestructure.entities
{
    public class User : Entity
    {
        public string Name { get; set; }

        public int UserTypeId { get; set; }

        public string Username { get; set; }
    }
}