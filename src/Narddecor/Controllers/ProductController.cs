using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Narddecor.Services;
using Narddecor.ViewModels.Product;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Narddecor.Controllers
{
	[Route("products")]
	public class ProductController : Controller
	{
		private readonly ProductService _productService;

		public ProductController(ProductService productService)
		{
			_productService = productService;
		}

		// GET: /<controller>/
		public IActionResult Index()
		{
			var categories = _productService.GetCategoriesWithProducts()
				.Select(c => new CategoryViewModel()
				{
					CategoryName = c.Name,
					Products = c.Products.Select(p => new ProductViewModel
					{
						CategoryId = p.CategoryId,
						UniqueName = p.UniqueName,
						Color = p.Color,
						Description = p.Description,
						SortOrder = p.SortOrder,
						ImagePath = p.ImagePath
					}).ToArray()
				}).ToArray();

			var vm = categories;

			return View("ProductList", categories);
		}

		[HttpGet("[action]")]
		public IActionResult Create()
		{
			var categories = _productService.GetCategories()
				.Select(c => new SelectListItem()
				{
					Text = c.Name,
					Value = c.CategoryId.ToString()
				}).ToArray(); ;

			var vm = new ProductEditViewModel
			{
				Categories = categories
			};

			return View(vm);
		}

		[HttpPost("[action]")]
		public IActionResult Create(ProductEditViewModel vm)
		{
			_productService.CreateProduct(vm.Product);

			var categories = _productService.GetCategories()
				.Select(c => new SelectListItem()
				{
					Text = c.Name,
					Value = c.CategoryId.ToString(),
					Selected = vm.Product.CategoryId == c.CategoryId
				}).ToArray();

			vm.Categories = categories;

			//RedirectToAction("Edit", vm.Product.UniqueName);

			return View(vm);
		}

		[HttpGet("{uniqueName}/[action]")]
		public IActionResult Edit(string uniqueName)
		{
			var product = _productService.GetProductBy(uniqueName);

			var productViewModel = new ProductViewModel()
			{
				CategoryId = product.CategoryId,
				UniqueName = product.UniqueName,
				Color = product.Color,
				Description = product.Description,
				SortOrder = product.SortOrder,
				ImagePath = product.ImagePath
			};

			var categoryItemsList = _productService.GetCategories()
				.Select(c => new SelectListItem()
				{
					Text = c.Name,
					Value = c.CategoryId.ToString(),
					Selected = product.CategoryId == c.CategoryId
				}).ToArray();

			var vm = new ProductEditViewModel
			{
				Categories = categoryItemsList,
				Product = productViewModel
			};

			return View(vm);
		}


		[HttpPost("{uniqueName}/[action]")]
		public IActionResult Edit(ProductEditViewModel vm, string uniqueName)
		{
			var productViewModel = new ProductViewModel()
			{
				CategoryId = vm.Product.CategoryId,
				UniqueName = vm.Product.UniqueName,
				Color = vm.Product.Color,
				Description = vm.Product.Description,
				SortOrder = vm.Product.SortOrder,
				ImagePath = vm.Product.ImagePath
			};

			_productService.UpdateProduct(productViewModel);
			
			var categoryItemsList = _productService.GetCategories()
				.Select(c => new SelectListItem()
				{
					Text = c.Name,
					Value = c.CategoryId.ToString(),
					Selected = vm.Product.CategoryId == c.CategoryId
				}).ToArray();

			vm.Categories = categoryItemsList;

			return View(vm);
		}

	}
}
