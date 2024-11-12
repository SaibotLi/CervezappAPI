using Cervezapp.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Cervezapp.Services;

public class CervezaDataStore 
{
public List<Cerveza> Cervezas {get; set; }

public CervezaDataStore()
{
 Cervezas = new List<Cerveza>() 
 {
new Cerveza() {
    Id = 1,
    Name = "Belga Rubia",
    Description = "Una cerveza belga ligera, espumosa y refrescante.",
    Steps = new List<Step>() {
        new Step() {
            Id = 0,
            Title = "IMPORTANTE",
            SubTitle = "Asegurate de que todo esté desinfectado y limpio antes de usarlo.",
             DescriptionPart = new DescriptionPart
                        {
                            Text = "Para el siguiente paso necesitarás:",
                            Items = new List<string> 
                            {
                                "4kg de Belgian Blonde dentro de bolsa maceradora",
                                "Olla de 20 litros llena de agua",
                                "Cuchara de madera",
                                "Termómetro"
                            }
                        }
        },
        new Step() {
            Id = 1,
            Title = "MACERACIÓN",
            SubTitle = "Primer paso: Maceración",
             DescriptionPart = new DescriptionPart
                        {
                              Items = new List<string> 
                            {
                                "Elevar temperatura de la olla a 70-72°",
                                "Colocar bolsa maceradora.",
                                "Iniciar cronómetro de 90 minutos.",
                                "Mantener temperatura entre 65-68°",
                                "Revolver el grano cada 15 minutos",
                                "OPCIONAL: Cerca del final hervir al menos 5L de agua para el recirculado"
                            },
                            Text = "Una vez pasados los 90 minutos, proceder al siguiente paso."
                        }
        }
    }
}
 }    
}
}