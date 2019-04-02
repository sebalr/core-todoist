using System;
using todoist.DTOs;
using todoist.Infraestructure.Entities;

namespace todoist.Entities
{
    public class ItemState : Entity
    {
        public virtual State State { get; set; }

        public DateTime Changed { get; set; }
    }
}