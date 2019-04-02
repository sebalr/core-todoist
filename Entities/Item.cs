using System;
using System.Collections.Generic;
using todoist.Entities.Relations;
using todoist.Infraestructure.Entities;

namespace todoist.Entities
{
    public class Item : EntityWithSoftDelete
    {
        public string Body { get; set; }

        public virtual ICollection<ItemCategory> Categories { get; set; }

        public DateTime Creation { get; set; }

        public virtual ItemState ItemState { get; set; }
    }
}