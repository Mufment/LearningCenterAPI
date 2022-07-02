using LearningCenterAPI.Learning.Domain.Repositories;
using LearningCenterAPI.Learning.Persistance.Contexts;

namespace LearningCenterAPI.Learning.Persistance.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;


    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }


    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}