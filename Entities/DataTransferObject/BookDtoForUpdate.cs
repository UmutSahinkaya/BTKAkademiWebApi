using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    // public record BookDtoForUpdate(int id, string Title, decimal Price);//(ctor tanımlar gibi bu şekilde de dto tanımlayabiliyoruz)
    public record BookDtoForUpdate : BookDtoForManipulation
    {
        [Required(ErrorMessage = "Id is a requried field.")]
        public int Id { get; set; }
    }
}
