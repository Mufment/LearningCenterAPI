using LearningCenterAPI.Learning.Domain.Models;
using LearningCenterAPI.Shared.Services.Communication;

namespace LearningCenterAPI.Learning.Domain.Services.Communication;

public class TutorialResponse : BaseResponse<Tutorial>
{
    public TutorialResponse(string message) : base(message)
    {
    }

    public TutorialResponse(Tutorial resource) : base(resource)
    {
    }
}