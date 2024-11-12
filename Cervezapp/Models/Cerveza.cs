namespace Cervezapp.Models;

public class Cerveza 
{
public int Id { get; set; }

public string Name { get; set; } = string.Empty;

public string Description {get; set;} = string.Empty;
public List<Step>? Steps { get; set; }
 public int Liters { get; set; } 

}