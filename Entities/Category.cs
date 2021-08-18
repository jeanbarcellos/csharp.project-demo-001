using Demo.Core.Domain;
using System;

namespace Demo.Entities
{
    public class Category : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
