using AutoMapper;
using LearningCenterAPI.Learning.Domain.Models;
using LearningCenterAPI.Learning.Resources;

namespace LearningCenterAPI.Learning.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Category, CategoryResource>();
        CreateMap<Tutorial, TutorialResource>();
    }
    
    
    
}