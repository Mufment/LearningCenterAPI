using LearningCenterAPI.Learning.Domain.Models;

namespace LearningCenterAPI.Learning.Domain.Repositories;

public interface ITutorialRepository
{
    Task<IEnumerable<Tutorial>> ListAsync();

    Task AddAsync(Tutorial tutorial);
    Task<Tutorial> FindByIdAsync(int tutorialid);
    Task<Tutorial> FindByNameAsync(string name);
    Task<Tutorial> FindByCategoryIdAsync(int categoryId);
    Task<IEnumerable<Tutorial>> DeleteAsync(int Tutorialid);

    void Update(Tutorial tutorial);
    void Remove(Tutorial tutorial);

}