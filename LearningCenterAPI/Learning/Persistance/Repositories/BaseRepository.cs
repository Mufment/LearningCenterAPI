using LearningCenterAPI.Learning.Persistance.Contexts;

namespace LearningCenterAPI.Learning.Persistance.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;


    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}