using System.ComponentModel.DataAnnotations;

namespace LearningCenterAPI.Learning.Resources;

public class SaveTutorialResource
{
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        
        [MaxLength(300)]
        public string Description { get; set; }
        [Required]
        public int CategoryId{ get; set; }
}