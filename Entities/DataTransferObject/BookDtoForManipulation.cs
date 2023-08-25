using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public abstract record BookDtoForManipulation
    {
        [Required(ErrorMessage ="Title is a requried field.")]
        [MinLength(2,ErrorMessage = "Title must consist of at least 2 characters")]
        [MaxLength(50, ErrorMessage = "Title must consist of at maximum 50 characters")]
        public string Title { get; init; }
        [Required(ErrorMessage = "Price is a requried field.")]
        [Range(10,1000)]
        public decimal Price { get; init; }
    } 
}
