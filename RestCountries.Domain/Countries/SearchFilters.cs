namespace RestCountries.Domain.Countries
{
  public class SearchFilters
  {
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchName { get; set; } = string.Empty;
    public string SearchRegion { get; set; } = string.Empty;
    public string SearchSubregion { get; set; } = string.Empty;
  }
}
