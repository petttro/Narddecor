using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Narddecor.Models
{
	public class Product
	{
		public string UniqueName { get; set; }
		public Category Category { get; set; }
		public string Color { get; set; }
		public string Description { get; set; }
		public int SortOrder { get; set; }
		public string FileName { get; set; }
		public string ImagePath{get; set; }
		public int CategoryId { get; set; }
	}
}
