using LearningCenterAPI.Learning.Domain.Models;

namespace LearningCenterAPI.Learning.Domain.Repositories;

public interface ITutorialRepository
{
    Task<IEnumerable<Tutorial>> ListAsync();

    Task AddAsync(Tutorial tutorial);
    Task<Tutorial> FindByIdAsync(int tutorialid);
    Task<Tutorial> FindByTitleAsync(string title);
    Task<IEnumerable<Tutorial>> FindByCategoryIdAsync(int categoryId);
 
    void Update(Tutorial tutorial);
    void Remove(Tutorial tutorial);

}