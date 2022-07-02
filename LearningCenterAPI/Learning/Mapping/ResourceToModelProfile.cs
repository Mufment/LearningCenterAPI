using AutoMapper;
using LearningCenterAPI.Learning.Domain.Models;
using LearningCenterAPI.Learning.Resources;

namespace LearningCenterAPI.Learning.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveCategoryResource, Category>();
        CreateMap<SaveTutorialResource, Tutorial>();
    }
}