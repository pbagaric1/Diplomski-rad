using System.Collections.Generic;

namespace Survey.Business.Models.ViewModels
{
  public class PagedResponse
  {
    public int Total { get; set; }
    public ICollection<PollView> Data { get; set; }
  }
}