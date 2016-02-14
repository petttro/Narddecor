using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Narddecor.Models;
using Narddecor.ViewModels.Product;

namespace Narddecor.Services
{
    interface IProductService 
    {
	    ProductEditViewModel GetProductBy(string uniqueName);
	    ICollection<Category> GetCategoriesWithProducts();
	    ICollection<Category> GetCategories();
	    void SaveProduct(ProductEditViewModel productViewModel);
    }
}
