using System;

namespace todoist.DTOs
{
    public enum State { Invalid = 0, New = 1, Done = 2 };

    public class ItemStateDTO
    {
        public State State { get; set; }

        public DateTime Changed { get; set; }
    }
}