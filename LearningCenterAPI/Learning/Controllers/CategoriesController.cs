using LearningCenterAPI.Learning.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenterAPI.Learning.Controllers;


[Route("/api/v1/[controller]")]
public class CategoriesController :ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;

    }
    
}