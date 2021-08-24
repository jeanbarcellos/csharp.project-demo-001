using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Api.ViewModel
{
    public class ProductViewModel
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public int Quantity { get; set; }

        public string Image { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
