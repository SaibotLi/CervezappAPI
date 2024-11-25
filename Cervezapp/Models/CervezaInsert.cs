using System.ComponentModel.DataAnnotations;

namespace Cervezapp;

public class CervezaInsert
{
    [Required]
    [MaxLength(20)]
public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(50)]
public string Description {get; set;} = string.Empty;

}