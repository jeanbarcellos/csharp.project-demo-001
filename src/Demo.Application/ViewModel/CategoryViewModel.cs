using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Application.ViewModel
{
    public class CategoryViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MaxLength(128, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Name { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
