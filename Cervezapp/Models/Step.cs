using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cervezapp.Models;
public class DescriptionPart {
    public string? Text { get; set; } // Texto opcional que puede ser null
    public List<string>? Items { get; set; } // Lista opcional que puede ser null

    public bool HasText => !string.IsNullOrEmpty(Text); // Chequea si hay texto o es null
    public bool HasItems => Items != null && Items.Any(); // Chequea si hay lista o es null
}
public class Step
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
        public string SubTitle { get; set; } = string.Empty;
    public DescriptionPart? DescriptionPart { get; set; }
    public int Time { get; set; }
}