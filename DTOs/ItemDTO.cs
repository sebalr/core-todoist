using System;
using System.Collections.Generic;

namespace todoist.DTOs
{
    public class ItemDTO
    {
        public string Body { get; set; }

        public IList<CategoryDTO> Categories { get; set; }

        public DateTime Creation { get; set; }

        public ItemStateDTO ItemState { get; set; }
    }
}