namespace LearningCenterAPI.Learning.Domain.Models;

public class Tutorial
{
    public int Id { get; set; } 
    public string Title{ get; set; } 
    public string Description{ get; set; } 
    
    public int CatergoryId { get; set; }
    public Category Category { get; set; }
    
    
}