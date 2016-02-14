using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Narddecor.ViewModels.Product
{
    public class ProductViewModel
    {
		[Required]
		[Display(Name = "Уникальное имя")]
		public string UniqueName { get; set; }

		[Display(Name = "Категория")]
		public int CategoryId { get; set; }

		[Display(Name = "Название / цвет")]
		public string Color { get; set; }

		[Display(Name = "Порядок сортировки")]
		public int SortOrder { get; set; }

		[Display(Name = "Описание")]
		public string Description { get; set; }

		[Display(Name = "Путь к картинке")]
		public string ImagePath { get; set; }
	}
}
