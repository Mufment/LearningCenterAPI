using LearningCenterAPI.Learning.Domain.Models;
using LearningCenterAPI.Shared.Services.Communication;

namespace LearningCenterAPI.Learning.Domain.Services.Communication;

public class CategoryResponse : BaseResponse<Category>
{
    public CategoryResponse(string message) : base(message)
    {
    }

    public CategoryResponse(Category resource) : base(resource)
    {
        
        
    }
}