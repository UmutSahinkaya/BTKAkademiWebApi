using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public record BookDtoForUpdate(int id,string Title,decimal Price);//(ctor tanımlar gibi bu şekilde de dto tanımlayabiliyoruz)
}
