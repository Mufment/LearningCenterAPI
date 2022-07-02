using AutoMapper;
using LearningCenterAPI.Learning.Domain.Models;
using LearningCenterAPI.Learning.Domain.Services;
using LearningCenterAPI.Learning.Resources;
using LearningCenterAPI.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenterAPI.Learning.Controllers;

[ApiController]
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
        var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);

        return resources;

    }

    public async Task<IActionResult> PostAsync([FromBody]SaveCategoryResource resource)
    {
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var category = _mapper.Map<SaveCategoryResource, Category>(resource);
        
        
        
        var result = await _categoryService.SaveAsync(category);

        if (!result.Success)
            return BadRequest(result.Message);
        var categoryResource =_mapper.Map< Category,CategoryResource>(result.Resource);
        return Ok(categoryResource);



    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id,[FromBody]SaveCategoryResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var category = _mapper.Map<SaveCategoryResource, Category>(resource);
        
        
        var result = await _categoryService.UpdateAsync(id,category);
        
        if (!result.Success)
            return BadRequest(result.Message);
        var categoryResource =_mapper.Map< Category,CategoryResource>(result.Resource);
        return Ok(categoryResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    { 
        
        var result = await _categoryService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        
        
        var categoryResource =_mapper.Map< Category,CategoryResource>(result.Resource);
        return Ok(categoryResource);
        
        
    }
}