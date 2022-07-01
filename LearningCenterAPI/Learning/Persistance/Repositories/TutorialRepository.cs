using LearningCenterAPI.Learning.Domain.Models;
using LearningCenterAPI.Learning.Domain.Repositories;
using LearningCenterAPI.Learning.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LearningCenterAPI.Learning.Persistance.Repositories;

public class TutorialRepository : BaseRepository, ITutorialRepository
{
    public TutorialRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Tutorial>> ListAsync()
    {
        return await _context.Tutorials
            .Include(p => p.Category)
            .ToListAsync();
    }

    public async Task AddAsync(Tutorial tutorial)
    {
         await _context.Tutorials.AddAsync(tutorial);
    }

    public async Task<Tutorial> FindByIdAsync(int tutorialid)
    {
        return await _context.Tutorials
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p=>p.Id==tutorialid);
    }

    public async Task<Tutorial> FindByTitleAsync(string title)
    {
        return await _context.Tutorials
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p=>p.Title ==title);
    }

    public async Task<IEnumerable<Tutorial>> FindByCategoryIdAsync(int categoryId)
    {
        return await _context.Tutorials
            .Where(p => p.CatergoryId==categoryId)
            .Include(p => p.Category)
            .ToListAsync();
    }

   

    public void Update(Tutorial tutorial)
    {
        _context.Categories.Update(tutorial);
    }

    public void Remove(Tutorial tutorial)
    {
        _context.Categories.Remove(tutorial);
    }
}