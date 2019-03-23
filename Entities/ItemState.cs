using System;
using todoist.DTOs;

namespace todoist.Entities
{
    public class ItemState
    {
        public State State { get; set; }

        public DateTime Changed { get; set; }
    }
}