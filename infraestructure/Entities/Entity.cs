namespace todoist.infraestructure.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}", Id);
        }
    }
    
    public abstract class EntityWithSoftDelete: Entity
    {
        public bool Deleted { get; set; }

    }
}