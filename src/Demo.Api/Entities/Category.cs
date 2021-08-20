using Demo.Api.Core.Domain;
using System;

namespace Demo.Api.Entities
{
    public class Category : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
