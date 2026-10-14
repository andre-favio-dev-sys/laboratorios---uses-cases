using System.ComponentModel.DataAnnotations;

namespace Lab07_Ancco_Andre.DTOs;

public class CreateProductDto
{
    [Required]
    public string Name { get; set; }
    [Required] 
    public string Price { get; set; }
    
    public string Description { get; set; }
}