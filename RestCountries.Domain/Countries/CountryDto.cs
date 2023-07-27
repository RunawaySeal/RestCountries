namespace RestCountries.Domain.Countries
{
  // Object to recieve and deserialize rest countries api json response.
  // This is used to create a more user friendly object that is returned.
  public class CountryDto
  {
    public NameDto Name { get; set; } = new NameDto();
    public string Region { get; set; } = string.Empty;
    public string Subregion { get; set; } = string.Empty;
    public List<string> Capital { get; set; } = new List<string>();
    public int Population { get; set; } = new int();
    public Dictionary<string, CurrencyDto> Currencies { get; set; } = new Dictionary<string, CurrencyDto>();
    public Dictionary<string, string> Languages { get; set; } = new Dictionary<string, string>();
    public List<string> Borders { get; set; } = new List<string>();
  }

  public class CurrencyDto
  {
    public string Name { get; set; } = string.Empty;
    public string Symbol { get; set; } = string.Empty;
  }

  public class NameDto
  {
    public string Common { get; set; } = string.Empty;
    public string Official { get; set; } = string.Empty;
  }
}
