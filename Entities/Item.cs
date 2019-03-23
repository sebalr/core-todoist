using System;
using System.Collections.Generic;
using todoist.Infraestructure.Entities;

namespace todoist.Entities
{
    public class Item: EntityWithSoftDelete
    {
        public string Body { get; set; }

        public ISet<Category> Categories { get; set; }

        public DateTime Creation { get; set; }
    }
}