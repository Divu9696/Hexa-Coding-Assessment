using System;
using System.Collections.Generic;
namespace PetPals.Entity;

public class AdoptionEvent
{
    public List<IAdoptable> Participants { get; set; } = new List<IAdoptable>();
}
