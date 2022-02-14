using Demo.Core.Domain;
using System;

namespace Demo.Domain.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        public Category Category { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Value { get; private set; }
        public int Quantity { get; private set; }
        public string Image { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        // EF Relation
        public Guid CategoryId { get; private set; }

        // EF
        protected Product()
        {

        }

        public Product(Category category, string name, string description, bool active, decimal value)
        {
            Category = category;
            Name = name;
            Description = description;
            Active = active;
            Value = value;
            Quantity = 0;
        }

        public void Activate() => Active = true;

        public void Desctivate() => Active = false;

        public bool HasQuantity(int quantity)
        {
            return Quantity >= quantity;
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void SubQuantity(int quantity)
        {
            Quantity -= quantity;
        }

        public void SetImage(string image)
        {
            Image = image;
        }
    }
}
