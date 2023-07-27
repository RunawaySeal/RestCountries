namespace RestCountries.Domain
{
  // Basic response object that allows you to return a list of type as well and the total results. 
  // This is used for pagination without needing to send the whole list.
  public class Response<T>
  {
    public int TotalResults { get; set; }
    public IEnumerable<T> Results { get; set; } = Enumerable.Empty<T>();
  }
}
