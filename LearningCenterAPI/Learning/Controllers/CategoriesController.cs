using AutoMapper;
using LearningCenterAPI.Learning.Domain.Models;
using LearningCenterAPI.Learning.Domain.Services;
using LearningCenterAPI.Learning.Resources;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenterAPI.Learning.Controllers;


[Route("/api/v1/[controller]")]
public class CategoriesController :ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;

    }

    [HttpGet]
    public async Task<IEnumerable<CategoryResource>> GetAllAsync()
    {
        var categories = await _categoryService.ListAsync();
        var resources = _mapper.Map<IEnumerable<CategoryResource>>(categories);

        return resources;

    }




}