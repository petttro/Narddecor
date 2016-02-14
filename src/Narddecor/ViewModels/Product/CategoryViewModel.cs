using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Narddecor.ViewModels.Product
{
    public class CategoryViewModel
    {
		public string CategoryName { get; set; }

		public ICollection<ProductViewModel> Products { get; set; }
    }
}
