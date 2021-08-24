using Demo.Core.Domain;
using System;
using System.Collections.Generic;

namespace Demo.Domain.Entities
{
    public class Category : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        // EF Relation
        public virtual ICollection<Product> Products { get; private set; }

        // EF
        protected Category()
        {
        }

        public Category(string name)
        {
            Name = name;
        }

        public void SetName(string name)
        {
            Name = name;
        }
    }

}
