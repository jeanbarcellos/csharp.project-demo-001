using Demo.Core;
using System;

namespace Demo.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
