
using LearningCenterAPI.Learning.Domain.Models;
using LearningCenterAPI.Learning.Domain.Repositories;
using LearningCenterAPI.Learning.Domain.Services;
using LearningCenterAPI.Learning.Domain.Services.Communication;

namespace LearningCenterAPI.Learning.Services;

public class TutorialService : ITutorialService
{
    public TutorialService(ITutorialRepository tutorialRepository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
    {
        _tutorialRepository = tutorialRepository;
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }

    private readonly ITutorialRepository _tutorialRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categoryRepository;

    
    
    public async Task<IEnumerable<Tutorial>> ListAsync()
    {
        return await _tutorialRepository.ListAsync();
    }

    public async Task<IEnumerable<Tutorial>> ListByCategoryIdAsync(int categoryId)
    {
        return await _tutorialRepository.FindByCategoryIdAsync(categoryId);
    }

    public async Task<TutorialResponse> SaveAsync(Tutorial tutorial)
    {
       //validate categoryID
       var existingCategory = await _categoryRepository.FindByIdAsync(tutorial.CatergoryId);

       if (existingCategory==null)
       {
           return new TutorialResponse("Invalid categoryId");
       }

       //validate Title
       var existingTutorialWithTitle = await _tutorialRepository.FindByTitleAsync(tutorial.Title);

     
              
       if (existingTutorialWithTitle!=null)
       {
           return new TutorialResponse("Tutorial title already exists");
       }
  
        //UpdateFiels 
       try
       {
           await _tutorialRepository.AddAsync(tutorial);

           await _unitOfWork.CompleteAsync();

           return new TutorialResponse(tutorial);

       }//Complete Update
       
         //Error Hangling
       catch (Exception e)
       {
           return new TutorialResponse($"An error has ocurred while saving");
       }
       
       
       
    }

    public async Task<TutorialResponse> UpdateAsync(int tutorialid, Tutorial tutorial)
    {
       // validate tutorial
        var existingTutorial = await _tutorialRepository.FindByIdAsync(tutorialid);
        if (existingTutorial==null)
        {
            return new TutorialResponse("Tutorial not found");
        }
        //validate categoryID
        var existingCategory = await _categoryRepository.FindByIdAsync(tutorial.CatergoryId);

        if (existingCategory==null)
        {
            return new TutorialResponse("Invalid categoryId");
        }
        
         //Validate Title
        var existingTutorialWithTitle = await _tutorialRepository.FindByTitleAsync(tutorial.Title);
       
        if (existingTutorialWithTitle!=null && existingTutorialWithTitle.Id!=tutorial.Id)
        {
            return new TutorialResponse("Tutorial title already exists");
        }
        
        //modify fields
        existingTutorial.Title = tutorial.Title;
        existingTutorial.Description = tutorial.Description;
        try
        {
             _tutorialRepository.Update(existingTutorial);
             await _unitOfWork.CompleteAsync();

            return new TutorialResponse(existingTutorial);

        }
        //Error Hangling
        catch (Exception e)
        {
            return new TutorialResponse($"An error has ocurred while Updating");
        }
        
    }

    public async Task<TutorialResponse> DeleteAsync(int tutorialid)
    {
        
        // validate tutorial
        var existingTutorial = await _tutorialRepository.FindByIdAsync(tutorialid);
        
        
        if (existingTutorial==null)
        {
            return new TutorialResponse("Tutorial not found");
        }
     
        try
        {
            _tutorialRepository.Remove(existingTutorial);
            await _unitOfWork.CompleteAsync();

            return new TutorialResponse(existingTutorial);

        }
        //Error Hangling
        catch (Exception e)
        {
            return new TutorialResponse($"An error has ocurred while Updating");
        }
        
    }
}