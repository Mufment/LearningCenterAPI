using LearningCenterAPI.Learning.Domain.Models;

namespace LearningCenterAPI.Learning.Domain.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> ListAsync();
    Task AddAsync(Category Category);
    Task<Category> FindByIdAsync(int id);

    void Update(Category Category);
    void Remove(Category Category);



}