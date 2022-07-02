using System.ComponentModel.DataAnnotations;

namespace LearningCenterAPI.Learning.Resources;

public class SaveCategoryResource
{
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
}