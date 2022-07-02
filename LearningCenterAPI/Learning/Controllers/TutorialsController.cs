using AutoMapper;
using LearningCenterAPI.Learning.Domain.Models;
using LearningCenterAPI.Learning.Domain.Services;
using LearningCenterAPI.Learning.Resources;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenterAPI.Learning.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TutorialsController : ControllerBase
{
    public TutorialsController(ITutorialService tutorialService, IMapper mapper)
    {
        _tutorialService = tutorialService;
        _mapper = mapper;
    }

    private readonly ITutorialService _tutorialService;
    private readonly IMapper _mapper;
    
    [HttpGet]
    public async Task<IEnumerable<TutorialResource>> GetAllAsync()
    {
        var tutorials = await _tutorialService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Tutorial>,IEnumerable<TutorialResource>>(tutorials);

        return resources;

    }
    
    
    
}