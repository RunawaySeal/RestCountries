using RestCountries.Domain.Countries;

namespace RestCountries.Domain.Subregions
{
  public class Subregion
  {
    public string Name { get; set; } = string.Empty;
    public int Population { get; set; }
    public string Region { get; set; } = string.Empty;
    public List<Country> Countries { get; set; } = new List<Country>();

    public Subregion(List<Country> countries)
    {
      if (!countries.Any())
        return;

      Countries = countries;
      Name = Countries[0].Subregion;
      Region = Countries[0].Region;
      Population = countries.Sum(c => c.Population);
    }
  }
}
