using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models;

public class Photo
{
    [Required]
    public IFormFile? Image { get; set; }
}