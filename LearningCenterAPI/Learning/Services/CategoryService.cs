
using LearningCenterAPI.Learning.Domain.Models;
using LearningCenterAPI.Learning.Domain.Repositories;
using LearningCenterAPI.Learning.Domain.Services;
using LearningCenterAPI.Learning.Domain.Services.Communication;

namespace LearningCenterAPI.Learning.Services;

public class CategoryService : ICategoryService
{
    public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
       _unitOfWork = unitOfWork;
    }

    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    
    
    public async Task<IEnumerable<Category>> ListAsync()
    {
        return await _categoryRepository.ListAsync();
    }

    public async Task<CategoryResponse> SaveAsync(Category Category)
    {
        try
        {
            await _categoryRepository.AddAsync(Category);
            await _unitOfWork.CompleteAsync();
            return new CategoryResponse(Category);
        }
        catch (Exception e)
        {
            return new CategoryResponse($"An error ocurrred");
        }
    }

    public async Task<CategoryResponse> UpdateAsync(int id, Category Category)
    {
        var existingCategory = await _categoryRepository.FindByIdAsync(id);
        if (existingCategory == null)
            return new CategoryResponse("Category not found");
        existingCategory.Name = Category.Name;
        try
        {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(existingCategory);
        }
        catch (Exception e)
        {
            return new CategoryResponse($"An error ocurred");
        }
    }

    public async Task<CategoryResponse> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}