using LearningCenterAPI.Learning.Domain.Models;
using LearningCenterAPI.Learning.Domain.Services.Communication;

namespace LearningCenterAPI.Learning.Domain.Services;

public interface  ICategoryService
{
    Task<IEnumerable<Category>> ListAsync();
    Task<CategoryResponse> SaveAsync(Category Category);
    Task<CategoryResponse> UpdateAsync(int id, Category Category);
    Task<CategoryResponse> DeleteAsync(int id);
   
    
}