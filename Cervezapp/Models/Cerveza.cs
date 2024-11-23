using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cervezapp.Models;

public class Cerveza 
{
    [Key] // Da a entender que el Primary Key es Id
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Da a entender que es autoincrementable
public int Id { get; set; }

public string Name { get; set; } = string.Empty;

public string Description {get; set;} = string.Empty;
public List<Step>? Steps { get; set; }

}