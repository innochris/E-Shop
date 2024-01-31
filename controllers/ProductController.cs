using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.controllers
{

	public class ProductController(AppStoreDbContext db) : BaseController
	{
		public AppStoreDbContext Db { get; } = db;

		[HttpGet("getproducts")]
		public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
		{
			var products = await Db.products.ToListAsync();
			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProductById(int id)
		{
			return await Db.products.FindAsync(id);
		}
	}
}