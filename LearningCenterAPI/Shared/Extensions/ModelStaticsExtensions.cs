using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LearningCenterAPI.Shared.Extensions;

public static class ModelStaticsExtensions
{
    public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
    {
        return dictionary.SelectMany(m => m.Value.Errors)
            .Select(m => m.ErrorMessage)
            .ToList();
    }
    
    
    
    
}