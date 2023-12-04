﻿using ApiCPlotek.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCPlotek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        public IConfiguration _configuration { get; }
        public CategoryController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategorys()
        {
            return _context.category.ToList();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryBy(int id)
        {
            var product = await _context.task.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return product.Category;
        }
        [HttpPost("{nazwa}")]
        public void CreateCategory(string nazwa)
        {
            _context.category.Add(new Category { Name = nazwa });
            _context.SaveChanges();
        }
        [HttpPut("{TaskId},{TagId}")]
        public async Task<IActionResult> UpdateCategory(int TaskID, int TagID)
        {
            var task = await _context.task.FindAsync(TaskID);
            var cat = await _context.category.FindAsync(TagID);
            if (task == null || cat == null)
            {
                return NotFound();
            }

            task.Category = cat;
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{TaskId},{TagId}")]
        public async Task<IActionResult> DeleteCategory(int TaskID, int TagID)
        {
            var task = await _context.task.FindAsync(TaskID);
            var cat = await _context.category.FindAsync(TagID);
            if (task == null || cat == null)
            {
                return NotFound();
            }

            task.Category = null;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
