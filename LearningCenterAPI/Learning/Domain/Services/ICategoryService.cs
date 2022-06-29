using LearningCenterAPI.Learning.Domain.Models;
using LearningCenterAPI.Learning.Domain.Services.Communication;

namespace LearningCenterAPI.Learning.Domain.Services;

public abstract class ICategoryService
{
    public abstract Task<IEnumerable<Category>> ListAsync();
    public abstract Task<CategoryResponse> SaveAsync(Category Category);
    public abstract Task<CategoryResponse> UpdateAsync(int id, Category Category);
    public abstract Task<CategoryResponse> DeleteAsync(int id, Category Category);
   
    
}