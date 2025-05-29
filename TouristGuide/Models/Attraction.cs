public class Attraction
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string History { get; set; }
    public string PhotoUrl { get; set; }
    public string WorkingHours { get; set; }
    public decimal? Price { get; set; }

    public int CityId { get; set; }
    public City City { get; set; }
}