using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock.Models.ViewModels
{
    public class shoppingCartVM
    {
        public IEnumerable<ShoppingCart> shoppingCartsList { get; set; }
        public double OrderTotal { get; set; }
    }
}
