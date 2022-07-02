using System.Net.Mime;
using AutoMapper;
using LearningCenterAPI.Learning.Domain.Models;
using LearningCenterAPI.Learning.Domain.Services;
using LearningCenterAPI.Learning.Resources;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenterAPI.Learning.Controllers;


  // api/v1/categories/1/tutorials <-----------Nested Resources
[ApiController]

[Route("/api/v1/categories/{categoryId}/tutorials")]

public class CategoryTutorialsController : ControllerBase

{ 
    private readonly ITutorialService _tutorialService;
    private readonly IMapper _mapper;
  
    [HttpGet]
    public async Task<IEnumerable<TutorialResource>> GetAllByCategoryIdAsync(int categoryId)
    {
        var tutorials = await _tutorialService.ListByCategoryIdAsync(categoryId);
        var resources = _mapper
            .Map<IEnumerable<Tutorial>, IEnumerable<TutorialResource>>(tutorials);
        return resources;

    }


}