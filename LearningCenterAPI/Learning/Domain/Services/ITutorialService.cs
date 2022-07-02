using LearningCenterAPI.Learning.Domain.Models;
using LearningCenterAPI.Learning.Domain.Services.Communication;

namespace LearningCenterAPI.Learning.Domain.Services;

public interface ITutorialService
{
    
    Task<IEnumerable<Tutorial>> ListAsync();
    Task<IEnumerable<Tutorial>> ListByCategoryIdAsync(int categoryId);
    
    Task<TutorialResponse> SaveAsync(Tutorial tutorial);
    Task<TutorialResponse> UpdateAsync(int tutorialid, Tutorial tutorial);
    Task<TutorialResponse> DeleteAsync(int tutorialid);

}