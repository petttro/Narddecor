using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;
using Narddecor.Models;

namespace Narddecor.ViewModels.Product
{
    public class ProductEditViewModel
    {
		public IEnumerable<SelectListItem> Categories { get; set; }

		public ProductViewModel Product { get; set; }
    }
}
