using LearningCenterAPI.Learning.Domain.Models;
using LearningCenterAPI.Learning.Domain.Services.Communication;

namespace LearningCenterAPI.Learning.Domain.Services;

public class ICategoryService
{
    public Task<IEnumerable<Category>> ListAsync();
    public Task<CategoryResponse> SaveAsync(Category Category);
    public Task<CategoryResponse> UpdateAsync(int id, Category);
    public Task<CategoryResponse> DeleteAsync(int id, Category);
   
    
}