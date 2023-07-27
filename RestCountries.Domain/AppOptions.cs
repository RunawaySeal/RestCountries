namespace RestCountries.Domain
{
  public class AppOptions
  {
    public string BaseUrl { get; set; } = string.Empty;
    public Logging Logging { get; set; } = new Logging();
  }

  public class Logging
  {
    public string Level { get; set; } = string.Empty;
    public string OutputTemplate { get; set; } = string.Empty;
    public string OutputPath { get; set; } = string.Empty;
  }
}
