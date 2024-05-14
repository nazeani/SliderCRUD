using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Core.Models
{
    public class Tag: BaseEntity
    {
       public string Name { get; set; }
       public List<Product> Product { get; set; }
    }
}
