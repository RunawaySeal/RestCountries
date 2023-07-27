using RestCountries.Domain.Countries;

namespace RestCountries.Domain.Regions
{
  public class Region
  {
    public string Name { get; set; } = string.Empty;

    // Asias population is too large for int so need to use long :)  
    public long Population { get; set; }
    public List<Country> Countries { get; set; } = new List<Country>();
    public List<string> Subregions { get; set; } = new List<string>();

    public Region(List<Country> countries)
    {
      if (!countries.Any()) 
        return;

      Countries = countries;
      Name = Countries[0].Region;
      Population = countries.Sum(c => (long)c.Population);
      Subregions = countries.Select(c => c.Subregion).Distinct().ToList();
    }
  }
}
