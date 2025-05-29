using System.Collections.Generic;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Region { get; set; }
    public int Population { get; set; }
    public string History { get; set; }
    public string CoatUrl { get; set; }
    public string PhotoUrl { get; set; }

    public List<Attraction> Attractions { get; set; } = new();
}