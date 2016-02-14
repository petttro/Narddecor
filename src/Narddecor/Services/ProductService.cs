using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Narddecor.Models;
using Narddecor.ViewModels.Product;

namespace Narddecor.Services
{
	public class ProductService
	{
		private readonly ApplicationDbContext _dbContext;

		public ProductService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Product GetProductBy(string uniqueName)
		{
			var categories = _dbContext.Categories
				.ToDictionary(c => c.CategoryId, c => c.Name);

			var product = _dbContext.Products
				.SingleOrDefault(p => p.UniqueName == uniqueName);

			if (product == null)
				return null;

			return product;
		}

		public ICollection<Category> GetCategoriesWithProducts()
		{
			var categories = _dbContext.Categories
				.Include(c => c.Products).ToArray();

			return categories;
		}

		public ICollection<Category> GetCategories()
		{
			return _dbContext.Categories.ToArray();
		}

		public void CreateProduct(ProductViewModel productViewModel)
		{
			var product = new Product
			{
				CategoryId = productViewModel.CategoryId,
				UniqueName = productViewModel.UniqueName,
				Color = productViewModel.Color,
				Description = productViewModel.Description,
				ImagePath = productViewModel.ImagePath,
				SortOrder = productViewModel.SortOrder
			};


			_dbContext.Products.Add(product);

			_dbContext.SaveChanges();
		}

		public void UpdateProduct(ProductViewModel productViewModel)
		{
			var isNew = false;

			var product = _dbContext.Products
				.SingleOrDefault(p => p.UniqueName == productViewModel.UniqueName);

			if (product == null)
			{
				isNew = true;
				product = new Product();
			}

			product.CategoryId = productViewModel.CategoryId;
			product.UniqueName = productViewModel.UniqueName;
			product.Color = productViewModel.Color;
			product.Description = productViewModel.Description;
			product.ImagePath = productViewModel.ImagePath;
			product.SortOrder = productViewModel.SortOrder;

			if (isNew)
				_dbContext.Products.Add(product);

			_dbContext.SaveChanges();
		}
	}
}
