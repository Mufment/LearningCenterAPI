using LearningCenterAPI.Learning.Controllers;
using LearningCenterAPI.Learning.Domain.Models;
using LearningCenterAPI.Learning.Domain.Repositories;
using LearningCenterAPI.Learning.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LearningCenterAPI.Learning.Persistance.Repositories;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Category>> ListAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task AddAsync(Category Category)
    {
        await _context.Categories.AddAsync(Category);
    }

    public  async Task<Category> FindByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async void Update(Category Category)
    {
        _context.Categories.Update(Category);
    }

    public void Remove(Category Category)
    {
        _context.Categories.Remove(Category);
    }
}